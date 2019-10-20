using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;

namespace TestsReadabilityDemos
{
    [TestClass]
    public class ProductPurchaseTestsWithPageObjects
    {
        private static Driver _driver;
        private static string _purchaseEmail;
        private static string _purchaseOrderNumber;
        private static MainPage _mainPage;
        private static CartPage _cartPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(Browser.Chrome);
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            _mainPage.AddRocketToShoppingCart();

            _cartPage.ApplyCoupon("happybirthday");

            Assert.AreEqual("Coupon code applied successfully.", _cartPage.GetMessageNotification());

            _cartPage.IncreaseProductQuantity(2);

            Assert.AreEqual("114.00€", _cartPage.GetTotal());

            _cartPage.ProceedToCheckout();

            var receivedMessage = _driver.FindElement(By.XPath("//h1"));
            Assert.AreEqual("Order received", receivedMessage.Text);
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenExistingClient()
        {
            AddRocketToShoppingCart();
            ApplyCoupon();
            IncreaseProductQuantity();

            var proceedToCheckout = _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));
            proceedToCheckout.Click();

            var loginHereLink = _driver.FindElement(By.LinkText("Click here to login"));
            loginHereLink.Click();
            Login("info@berlinspaceflowers.com");

            var placeOrderButton = _driver.FindElement(By.Id("place_order"));
            placeOrderButton.Click();

            Thread.Sleep(4000);
            var receivedMessage = _driver.FindElement(By.XPath("//h1"));
            Assert.AreEqual("Order received", receivedMessage.Text);

            var orderNumber = _driver.FindElement(By.XPath("//*[@id='post-7']/div/div/div/ul/li[1]/strong"));
            _purchaseOrderNumber = orderNumber.Text;
        }

        private void Login(string userName)
        {
            var userNameTextField = _driver.FindElement(By.Id("username"));
            userNameTextField.TypeText(userName);
            var passwordField = _driver.FindElement(By.Id("password"));
            passwordField.TypeText(GetUserPasswordFromDb(userName));
            var loginButton = _driver.FindElement(By.XPath("//button[@name='login']"));
            loginButton.Click();
        }

        private void IncreaseProductQuantity()
        {
            var quantityBox = _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
            quantityBox.TypeText("2");

            Thread.Sleep(2000);
            var updateCart = _driver.FindElement(By.CssSelector("[value*='Update cart']"));
            updateCart.Click();
            Thread.Sleep(4000);

            var totalSpan = _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
            Assert.AreEqual("114.00€", totalSpan.Text);
        }

        private void ApplyCoupon()
        {
            var couponCodeTextField = _driver.FindElement(By.Id("coupon_code"));
            couponCodeTextField.TypeText("happybirthday");

            var applyCouponButton = _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
            applyCouponButton.Click();

            Thread.Sleep(2000);
            var messageAlert = _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
            Assert.AreEqual("Coupon code applied successfully.", messageAlert.Text);
        }

        private void AddRocketToShoppingCart()
        {
            _driver.GoToUrl("http://demos.bellatrix.solutions/");

            var addToCartFalcon9 = _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
            addToCartFalcon9.Click();
            var viewCartButton = _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));
            viewCartButton.Click();
        }

        private string GetUserPasswordFromDb(string userName)
        {
            return "@purISQzt%%DYBnLCIhaoG6$";
        }

        private string GenerateUniqueEmail()
        {
            return $"{Guid.NewGuid()}@berlinspaceflowers.com";
        }
    }
}