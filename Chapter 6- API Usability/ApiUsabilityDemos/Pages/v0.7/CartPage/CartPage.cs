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
            CartPageElements = new CartPageElements(elementFindService);
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
