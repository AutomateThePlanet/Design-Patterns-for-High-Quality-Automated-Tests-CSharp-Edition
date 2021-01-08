// Copyright 2021 Automate The Planet Ltd.
// Author: Anton Angelov
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace StabilizeTestsDemos.SecondVersion
{
    /*
    * The order of test execution is important. The tests should be executed in the following order:
    * CompletePurchaseSuccessfully_WhenNewClient
    * CompletePurchaseSuccessfully_WhenExistingClient
    * CorrectOrderDataDisplayed_WhenNavigateToMyAccountOrderSection
    *
    * The tests may fail because the hard-coded pauses were not enough.
    * This is the expected behavior showing that this is not the best practice.
    */
    [TestClass]
    public class ProductPurchaseTests
    {
        private static IWebDriver _driver;
        private static string _purchaseEmail;
        private static string _purchaseOrderNumber;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new ChromeDriver(Environment.CurrentDirectory);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            AddRocketToShoppingCart();

            ApplyCoupon();

            IncreaseProductQuantity();

            var proceedToCheckout = WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var billingFirstName = WaitAndFindElement(By.Id("billing_first_name"));
            billingFirstName.SendKeys("Anton");
            var billingLastName = WaitAndFindElement(By.Id("billing_last_name"));
            billingLastName.SendKeys("Angelov");
            var billingCompany = WaitAndFindElement(By.Id("billing_company"));
            billingCompany.SendKeys("Space Flowers");
            var billingCountryWrapper = WaitAndFindElement(By.Id("select2-billing_country-container"));
            billingCountryWrapper.Click();
            var billingCountryFilter = WaitAndFindElement(By.ClassName("select2-search__field"));
            billingCountryFilter.SendKeys("Germany");

            var germanyOption = WaitAndFindElement(By.XPath("//*[contains(text(),'Germany')]"));
            germanyOption.Click();

            var billingAddress1 = WaitAndFindElement(By.Id("billing_address_1"));
            billingAddress1.SendKeys("1 Willi Brandt Avenue Tiergarten");
            var billingAddress2 = WaitAndFindElement(By.Id("billing_address_2"));
            billingAddress2.SendKeys("Lützowplatz 17");
            var billingCity = WaitAndFindElement(By.Id("billing_city"));
            billingCity.SendKeys("Berlin");
            var billingZip = WaitAndFindElement(By.Id("billing_postcode"));
            billingZip.Clear();
            billingZip.SendKeys("10115");
            var billingPhone = WaitAndFindElement(By.Id("billing_phone"));
            billingPhone.SendKeys("+00498888999281");
            var billingEmail = WaitAndFindElement(By.Id("billing_email"));
            billingEmail.SendKeys("info@berlinspaceflowers.com");
            _purchaseEmail = "info@berlinspaceflowers.com";

            // This pause will be removed when we introduce a logic for waiting for AJAX requests.
            Thread.Sleep(5000);
            var placeOrderButton = WaitAndFindElement(By.Id("place_order"));
            placeOrderButton.Click();
           
            var receivedMessage = WaitAndFindElement(By.XPath("//h1[text() = 'Order received']"));
            Assert.AreEqual("Order received", receivedMessage.Text);
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenExistingClient()
        {
            AddRocketToShoppingCart();
            ApplyCoupon();
            IncreaseProductQuantity();

            var proceedToCheckout = WaitAndFindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var loginHereLink = WaitAndFindElement(By.LinkText("Click here to login"));
            loginHereLink.Click();
            Login(_purchaseEmail);

            // This pause will be removed when we introduce a logic for waiting for AJAX requests.
            Thread.Sleep(5000);
            var placeOrderButton = WaitAndFindElement(By.Id("place_order"));
            placeOrderButton.Click();

            var receivedMessage = WaitAndFindElement(By.XPath("//h1[text() = 'Order received']"));
            Assert.AreEqual("Order received", receivedMessage.Text);

            var orderNumber = WaitAndFindElement(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
            _purchaseOrderNumber = orderNumber.Text;
        }

        [TestMethod]
        public void CorrectOrderDataDisplayed_WhenNavigateToMyAccountOrderSection()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var myAccountLink = WaitAndFindElement(By.LinkText("My account"));
            myAccountLink.Click();

            Login(_purchaseEmail);

            var orders = WaitAndFindElement(By.LinkText("Orders"));
            orders.Click();

            var viewButtons = WaitAndFindElements(By.LinkText("View"));
            viewButtons[0].Click();

            var orderName = WaitAndFindElement(By.XPath("//h1"));
            string expectedMessage = $"Order #{_purchaseOrderNumber}";
            Assert.AreEqual(expectedMessage, orderName.Text);
        }

        private void Login(string userName)
        {
            var userNameTextField = WaitAndFindElement(By.Id("username"));
            // This pause will be removed when we introduce a logic for waiting for AJAX requests.
            Thread.Sleep(5000);
            userNameTextField.SendKeys(userName);
            var passwordField = WaitAndFindElement(By.Id("password"));
            passwordField.SendKeys(GetUserPasswordFromDb(userName));
            var loginButton = WaitAndFindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = WaitAndFindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            quantityBox.SendKeys("2");

            WaitToBeClickable(By.CssSelector("[value*='Update cart']"));
            var updateCart = WaitAndFindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(4000);

            var totalSpan = WaitAndFindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = WaitAndFindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");

            var applyCouponButton = WaitAndFindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();

            Thread.Sleep(5000);
            var messageAlert = WaitAndFindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
        }

        private void AddRocketToShoppingCart()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var addToCartFalcon9 = WaitAndFindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            var viewCartButton = WaitAndFindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();
        }

        private string GetUserPasswordFromDb(string userName)
        {
            return "@purISQzt%%DYBnLCIhaoG6$";
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }

        private IWebElement WaitAndFindElement(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            return webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
        }

        private ReadOnlyCollection<IWebElement> WaitAndFindElements(By by)
        {
            var webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
            return webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }
    }
}