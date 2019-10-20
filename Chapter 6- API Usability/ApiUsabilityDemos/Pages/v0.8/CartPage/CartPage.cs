namespace ApiUsabilityDemos.Eight
{
    public class CartPage : NavigatableEShopPage<CartPage>
    {
        private readonly IBrowserService _browserService;

        public CartPage() 
        {
            _browserService = LoggingSingletonDriver.Instance;
            BreadcrumbSection = new BreadcrumbSection(LoggingSingletonDriver.Instance);
            CartPageElements = new CartPageElements(LoggingSingletonDriver.Instance);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; set; }
        public CartPageElements CartPageElements { get; set; }


        public void ApplyCoupon(string coupon)
        {
            CartPageElements.CouponCodeTextField.TypeText(coupon);
            CartPageElements.ApplyCouponButton.Click();
            _browserService.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            CartPageElements.QuantityBox.TypeText(newQuantity.ToString());
            CartPageElements.UpdateCart.Click();
            _browserService.WaitForAjax();
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
