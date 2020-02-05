namespace ApiUsabilityDemos.Seventh
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(IElementFindService elementFindService, INavigationService navigationService) 
            : base(elementFindService, navigationService)
        {
            Elements = new MainPageElements(elementFindService);
            Assertions = new MainPageAssertions(Elements);
        }

        public MainPageElements Elements { get; }
        public MainPageAssertions Assertions { get; }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart()
        {
            Open();
            Elements.AddToCartFalcon9.Click();
            Elements.ViewCartButton.Click();
        }

        protected override void WaitForPageLoad()
        {
            Elements.AddToCartFalcon9.WaitToExists();
        }
    }
}