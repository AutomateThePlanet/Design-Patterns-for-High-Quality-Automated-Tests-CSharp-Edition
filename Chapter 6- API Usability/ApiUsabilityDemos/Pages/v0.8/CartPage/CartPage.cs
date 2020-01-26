namespace ApiUsabilityDemos.Eight
{
    public class CartPage : NavigatableEShopPage<CartPage>
    {
        private readonly IBrowserService _browserService;

        public CartPage() 
        {
            _browserService = LoggingSingletonDriver.Instance;
            BreadcrumbSection = new BreadcrumbSection(LoggingSingletonDriver.Instance);
            Elements = new CartPageElements(LoggingSingletonDriver.Instance);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; set; }
        public CartPageElements Elements { get; set; }


        public void ApplyCoupon(string coupon)
        {
            Elements.CouponCodeTextField.TypeText(coupon);
            Elements.ApplyCouponButton.Click();
            _browserService.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            Elements.QuantityBox.TypeText(newQuantity.ToString());
            Elements.UpdateCart.Click();
            _browserService.WaitForAjax();
        }

        public void ProceedToCheckout()
        {
            Elements.ProceedToCheckout.Click();
        }

        public string GetTotal()
        {
            return Elements.TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return Elements.MessageAlert.Text;
        }

        protected override void WaitForPageLoad()
        {
            Elements.CouponCodeTextField.WaitToExists();
        }
    }
}
