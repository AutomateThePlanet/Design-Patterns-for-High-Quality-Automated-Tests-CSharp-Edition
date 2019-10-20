using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Facades.First
{
    [TestClass]
    public class FacadeTests
    {
        private static Driver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;
        private static PurchaseFacade _purchaseFacade;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(Browser.Chrome);
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _purchaseFacade = new PurchaseFacade(_mainPage, _cartPage, _checkoutPage);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void PurchaseFalcon9WithoutFacade()
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart("Falcon 9");
            _cartPage.ApplyCoupon("happybirthday");
            _cartPage.CartPageAssertions.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(2);
            _cartPage.CartPageAssertions.AssertTotalPrice("114.00€");
            _cartPage.CartPageElements.ProceedToCheckout.Click();

            var purchaseInfo = new PurchaseInfo()
                               {
                                   FirstName = "Anton",
                                   LastName = "Angelov",
                                   Company = "Space Flowers",
                                   Country = "Germany",
                                   Address1 = "1 Willi Brandt Avenue Tiergarten",
                                   Address2 = "Lützowplatz 17",
                                   City = "Berlin",
                                   Zip = "10115",
                                   Phone = "+00498888999281",
                               };
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.CheckoutPageAssertions.AssertOrderReceived();
        }

        [TestMethod]
        public void PurchaseSaturnVWithoutFacade()
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart("Saturn V");
            _cartPage.ApplyCoupon("happybirthday");
            _cartPage.CartPageAssertions.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(3);
            _cartPage.CartPageAssertions.AssertTotalPrice("355.00€");
            _cartPage.CartPageElements.ProceedToCheckout.Click();

            var purchaseInfo = new PurchaseInfo()
                               {
                                   FirstName = "John",
                                   LastName = "Atanasov",
                                   Company = "Space Flowers",
                                   Country = "Germany",
                                   Address1 = "1 Willi Brandt Avenue Tiergarten",
                                   Address2 = "Lützowplatz 17",
                                   City = "Berlin",
                                   Zip = "10115",
                                   Phone = "+00498888999281",
                               };
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.CheckoutPageAssertions.AssertOrderReceived();
        }

        [TestMethod]
        public void PurchaseFalcon9WithFacade()
        {
            var purchaseInfo = new PurchaseInfo()
                               {
                                   FirstName = "Anton",
                                   LastName = "Angelov",
                                   Company = "Space Flowers",
                                   Country = "Germany",
                                   Address1 = "1 Willi Brandt Avenue Tiergarten",
                                   Address2 = "Lützowplatz 17",
                                   City = "Berlin",
                                   Zip = "10115",
                                   Phone = "+00498888999281",
                               };

            _purchaseFacade.PurchaseItem("Falcon 9", "happybirthday", 2, "114.00€", purchaseInfo);
        }

        [TestMethod]
        public void PurchaseSaturnVWithFacade()
        {
            var purchaseInfo = new PurchaseInfo()
                               {
                                   FirstName = "John",
                                   LastName = "Atanasov",
                                   Company = "Space Flowers",
                                   Country = "Germany",
                                   Address1 = "1 Willi Brandt Avenue Tiergarten",
                                   Address2 = "Lützowplatz 17",
                                   City = "Berlin",
                                   Zip = "10115",
                                   Phone = "+00498888999281",
                               };

            _purchaseFacade.PurchaseItem("Saturn V", "happybirthday", 3, "355.00€", purchaseInfo);
        }
    }
}