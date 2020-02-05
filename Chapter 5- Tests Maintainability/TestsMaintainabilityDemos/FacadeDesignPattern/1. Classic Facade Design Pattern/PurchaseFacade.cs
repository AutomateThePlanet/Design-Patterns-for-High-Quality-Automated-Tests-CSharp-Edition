namespace TestsMaintainabilityDemos.Facades.First
{
    public class PurchaseFacade
    {
        private readonly MainPage _mainPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;

        public PurchaseFacade(MainPage mainPage, CartPage cartPage, CheckoutPage checkoutPage)
        {
            _mainPage = mainPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
        }

        public void PurchaseItem(string rocketName, string couponName, int quantity, string expectedPrice, PurchaseInfo purchaseInfo)
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart(rocketName);
            _cartPage.ApplyCoupon(couponName);
            _cartPage.Assertions.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(quantity);
            _cartPage.Assertions.AssertTotalPrice(expectedPrice);
            _cartPage.Elements.ProceedToCheckout.Click();
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.Assertions.AssertOrderReceived();
        }
    }
}
