namespace ApiUsabilityDemos.Ninth
{
    public class CartPage : NavigatableEShopPage
    {
        private CartPage(Driver driver) : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            CartPageElements = new CartPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; set; }
        public CartPageElements CartPageElements { get; set; }


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

        public void ProceedToCheckout()
        {
            CartPageElements.ProceedToCheckout.Click();
        }

        public string GetTotal()
        {
            return CartPageElements.TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return CartPageElements.MessageAlert.Text;
        }

        protected override void WaitForElementToDisplay()
        {
            CartPageElements.CouponCodeTextField.WaitToExists();
        }
    }
}
