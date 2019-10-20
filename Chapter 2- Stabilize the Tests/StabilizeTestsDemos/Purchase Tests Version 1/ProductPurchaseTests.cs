using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace StabilizeTestsDemos.FirstVersion
{
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
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var addToCartFalcon9 = _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(500);
            var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();

            var couponCodeTextField = _driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");
            var applyCouponButton = _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();
            Thread.Sleep(2000);
            var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);

            var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            Thread.Sleep(50);
            quantityBox.SendKeys("2");

            Thread.Sleep(2000);
            var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(2000);
            var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);

            var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var billingFirstName = _driver.FindElement(By.Id("billing_first_name"));
            billingFirstName.SendKeys("Anton");
            var billingLastName = _driver.FindElement(By.Id("billing_last_name"));
            billingLastName.SendKeys("Angelov");
            var billingCompany = _driver.FindElement(By.Id("billing_company"));
            billingCompany.SendKeys("Space Flowers");
            var billingCountryWrapper = _driver.FindElement(By.Id("select2-billing_country-container"));
            billingCountryWrapper.Click();
            var billingCountryFilter = _driver.FindElement(By.ClassName("select2-search__field"));
            billingCountryFilter.SendKeys("Germany");
            var germanyOption = _driver.FindElement(By.XPath("//*[contains(text(),'Germany')]"));
            germanyOption.Click();
            var billingAddress1 = _driver.FindElement(By.Id("billing_address_1"));
            billingAddress1.SendKeys("1 Willi Brandt Avenue Tiergarten");
            var billingAddress2 = _driver.FindElement(By.Id("billing_address_2"));
            billingAddress2.SendKeys("Lützowplatz 17");
            var billingCity = _driver.FindElement(By.Id("billing_city"));
            billingCity.SendKeys("Berlin");
            var billingZip = _driver.FindElement(By.Id("billing_postcode"));
            billingZip.Clear();
            billingZip.SendKeys("10115");
            var billingPhone = _driver.FindElement(By.Id("billing_phone"));
            billingPhone.SendKeys("+00498888999281");
            var billingEmail = _driver.FindElement(By.Id("billing_email"));
            billingEmail.SendKeys("info@berlinspaceflowers.com");
            _purchaseEmail = "info@berlinspaceflowers.com";
            var createAccountCheckBox = _driver.FindElement(By.Id("createaccount"));
            createAccountCheckBox.Click();
            var checkPaymentsRadioButton = _driver.FindElement(By.CssSelector("[for*='payment_method_cheque']"));
            checkPaymentsRadioButton.Click();
            var placeOrderButton = _driver.FindElement(By.Id("place_order"));
            placeOrderButton.Click();

            Thread.Sleep(2000);
            var receivedMessage = _driver.FindElement(By.XPath("//h1"));
            Assert.AreEqual("Order received", receivedMessage.Text);
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenExistingClient()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var addToCartFalcon9 = _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            Thread.Sleep(500);
            var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();

            var couponCodeTextField = _driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.Clear();
            couponCodeTextField.SendKeys("happybirthday");
            var applyCouponButton = _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();
            Thread.Sleep(2000);
            var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);

            var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.Clear();
            Thread.Sleep(50);
            quantityBox.SendKeys("2");
            Thread.Sleep(2000);
            var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(2000);
            var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);

            var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var loginHereLink = _driver.FindElement(By.LinkText("Click here to login"));
            loginHereLink.Click();
            var userName = _driver.FindElement(By.Id("username"));
            userName.SendKeys(_purchaseEmail);
            var password = _driver.FindElement(By.Id("password"));
            password.SendKeys(GetUserPasswordFromDb(_purchaseEmail));
            var loginButton = _driver.FindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();
         
            var placeOrderButton = _driver.FindElement(By.Id("place_order"));
            placeOrderButton.Click();

            Thread.Sleep(2000);
            var receivedMessage = _driver.FindElement(By.XPath("//h1"));
            Assert.AreEqual("Order received", receivedMessage.Text);

            var orderNumber = _driver.FindElement(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
            _purchaseOrderNumber = orderNumber.Text;
        }

        [TestMethod]
        public void CorrectOrderDataDisplayed_WhenNavigateToMyAccountOrderSection()
        {
            _driver.Navigate().GoToUrl("http://demos.bellatrix.solutions/");

            var myAccountLink = _driver.FindElement(By.LinkText("My account"));
            myAccountLink.Click();
            var userName = _driver.FindElement(By.Id("username"));
            userName.SendKeys(_purchaseEmail);
            var password = _driver.FindElement(By.Id("password"));
            password.SendKeys(GetUserPasswordFromDb(GetUserPasswordFromDb(_purchaseEmail)));
            var loginButton = _driver.FindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();

            Thread.Sleep(2000);
            var orders = _driver.FindElement(By.LinkText("Orders"));
            orders.Click();

            Thread.Sleep(2000);
            var viewButtons = _driver.FindElements(By.LinkText("View"));
            viewButtons[0].Click();
            Thread.Sleep(2000);

            var orderName = _driver.FindElement(By.XPath("//h1"));
            string expectedMessage = string.Format("Order #{0}", _purchaseOrderNumber);
            Assert.AreEqual(expectedMessage, orderName.Text);
        }

        private string GetUserPasswordFromDb(string userName)
        {
            return "@purISQzt%%DYBnLCIhaoG6$";
        }
    }
}