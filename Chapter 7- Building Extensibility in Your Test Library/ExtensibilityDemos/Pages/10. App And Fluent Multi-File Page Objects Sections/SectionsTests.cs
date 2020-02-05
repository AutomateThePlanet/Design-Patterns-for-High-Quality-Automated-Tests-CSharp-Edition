using ExtensibilityDemos.Pages.Tenth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensibilityDemos.Tenth
{
    [TestClass]
    public class SectionsTests
    {
        private static App _app;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _app = new App();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _app.Dispose();
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            var mainPage = _app.GoTo<MainPage>();

            mainPage.AddRocketToShoppingCart();

            var cartPage = _app.GoTo<CartPage>();
            cartPage.ApplyCoupon("happybirthday")
                .AssertMessageNotification("Coupon code applied successfully.")
                .IncreaseProductQuantity(2)
                .AssertTotal("114.00€")
                .ProceedToCheckout();
        }
    }
}