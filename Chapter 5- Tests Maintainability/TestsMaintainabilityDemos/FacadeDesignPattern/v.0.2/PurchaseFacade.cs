namespace TestsMaintainabilityDemos.Facades.Second
{
    public abstract class PurchaseFacade
    {
        public void PurchaseItem(string rocketName, string couponName, int quantity, string expectedPrice, PurchaseInfo purchaseInfo)
        {
            AddItemToShoppingCart(rocketName);
            ApplyCoupon(couponName);
            AssertCouponAppliedSuccessfully();
            IncreaseProductQuantity(quantity);
            AssertTotalPrice(expectedPrice);
            ProceedToCheckout();
            FillBillingInfo(purchaseInfo);
            AssertOrderReceived();
        }

        protected abstract void AddItemToShoppingCart(string itemName);
        protected abstract void ApplyCoupon(string couponName);
        protected abstract void AssertCouponAppliedSuccessfully();
        protected abstract void IncreaseProductQuantity(int quantity);
        protected abstract void AssertTotalPrice(string expectedPrice);
        protected abstract void ProceedToCheckout();
        protected abstract void FillBillingInfo(PurchaseInfo purchaseInfo);
        protected abstract void AssertOrderReceived();
    }
}
