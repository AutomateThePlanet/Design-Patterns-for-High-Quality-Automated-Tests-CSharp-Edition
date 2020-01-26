namespace ApiUsabilityDemos.Facades.First
{
    public class CartPage : EShopPage
    {
        public CartPage(Driver driver)
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            Elements = new CartPageElements(driver);
            Assertions = new CartPageAssertions(Elements);
        }

        public BreadcrumbSection BreadcrumbSection { get; set; }
        public CartPageElements Elements { get; set; }
        public CartPageAssertions Assertions { get; set; }

        public void ApplyCoupon(string coupon)
        {
            Elements.CouponCodeTextField.TypeText(coupon);
            Elements.ApplyCouponButton.Click();
            Driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            Elements.QuantityBox.TypeText(newQuantity.ToString());
            Elements.UpdateCart.Click();
            Driver.WaitForAjax();
        }
    }
}
