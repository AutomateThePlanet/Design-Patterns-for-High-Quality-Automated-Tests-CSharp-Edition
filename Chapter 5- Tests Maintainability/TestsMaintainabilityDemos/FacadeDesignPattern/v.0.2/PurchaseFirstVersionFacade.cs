namespace TestsMaintainabilityDemos.Facades.Second
{
    public class PurchaseFirstVersionFacade : PurchaseFacade
    {
        private readonly MainPage _mainPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;

        public PurchaseFirstVersionFacade(MainPage mainPage, CartPage cartPage, CheckoutPage checkoutPage)
        {
            _mainPage = mainPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
        }

        protected override void AddItemToShoppingCart(string itemName)
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart(itemName);
        }

        protected override void ApplyCoupon(string couponName)
        {
            _cartPage.ApplyCoupon(couponName);
        }

        protected override void AssertCouponAppliedSuccessfully()
        {
            _cartPage.Assertions.AssertCouponAppliedSuccessfully();
        }

        protected override void AssertOrderReceived()
        {
            _checkoutPage.Assertions.AssertOrderReceived();
        }

        protected override void AssertTotalPrice(string expectedPrice)
        {
            _cartPage.Assertions.AssertTotalPrice(expectedPrice);
        }

        protected override void FillBillingInfo(PurchaseInfo purchaseInfo)
        {
            _checkoutPage.FillBillingInfo(purchaseInfo);
        }

        protected override void IncreaseProductQuantity(int quantity)
        {
            _cartPage.IncreaseProductQuantity(quantity);
        }

        protected override void ProceedToCheckout()
        {
            _cartPage.Elements.ProceedToCheckout.Click();
        }
    }
}
