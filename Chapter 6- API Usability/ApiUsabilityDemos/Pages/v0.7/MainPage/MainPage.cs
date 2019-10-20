namespace ApiUsabilityDemos.Seventh
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(IElementFindService elementFindService, INavigationService navigationService) 
            : base(elementFindService, navigationService)
        {
            MainPageElements = new MainPageElements(elementFindService);
            MainPageAssertions = new MainPageAssertions(MainPageElements);
        }

        public MainPageElements MainPageElements { get; set; }
        public MainPageAssertions MainPageAssertions { get; set; }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart()
        {
            Open();
            MainPageElements.AddToCartFalcon9.Click();
            MainPageElements.ViewCartButton.Click();
        }

        protected override void WaitForElementToDisplay()
        {
            MainPageElements.AddToCartFalcon9.WaitToExists();
        }
    }
}