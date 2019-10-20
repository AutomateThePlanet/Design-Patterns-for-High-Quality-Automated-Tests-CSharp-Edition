namespace AssessmentSystemDemos.Facades.Second
{
    public class CartPage : EShopPage
    {
        public CartPage(Driver driver) : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            CartPageElements = new CartPageElements(driver);
            CartPageAssertions = new CartPageAssertions(CartPageElements);
        }

        public BreadcrumbSection BreadcrumbSection { get; set; }
        public CartPageElements CartPageElements { get; set; }
        public CartPageAssertions CartPageAssertions { get; set; }

        public void ApplyCoupon(string coupon)
        {
            CartPageElements.CouponCodeTextField.TypeText(coupon);
            CartPageElements.ApplyCouponButton.Click();
            Driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            CartPageElements.QuantityBox.TypeText(newQuantity.ToString());
            CartPageElements.UpdateCart.Click();
            Driver.WaitForAjax();
        }
    }
}
