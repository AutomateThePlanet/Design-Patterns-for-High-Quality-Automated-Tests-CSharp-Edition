namespace TestDataPreparationDemos.Facades.Second
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
            _cartPage.CartPageAssertions.AssertCouponAppliedSuccessfully();
        }

        protected override void AssertOrderReceived()
        {
            _checkoutPage.CheckoutPageAssertions.AssertOrderReceived();
        }

        protected override void AssertTotalPrice(string expectedPrice)
        {
            _cartPage.CartPageAssertions.AssertTotalPrice(expectedPrice);
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
            _cartPage.CartPageElements.ProceedToCheckout.Click();
        }
    }
}
