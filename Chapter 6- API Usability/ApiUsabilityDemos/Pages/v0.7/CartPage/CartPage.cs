namespace ApiUsabilityDemos.Seventh
{
    public class CartPage : NavigatableEShopPage
    {
        private readonly IBrowserService _browserService;

        public CartPage(IElementFindService elementFindService, INavigationService navigationService, IBrowserService browserService) 
            : base(elementFindService, navigationService)
        {
            _browserService = browserService;
            BreadcrumbSection = new BreadcrumbSection(elementFindService);
            Elements = new CartPageElements(elementFindService);
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
