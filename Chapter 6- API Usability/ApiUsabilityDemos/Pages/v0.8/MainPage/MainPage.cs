namespace ApiUsabilityDemos.Eight
{
    public class MainPage : NavigatableEShopPage<MainPage>
    {
        public MainPage() 
        {
            MainPageElements = new MainPageElements(LoggingSingletonDriver.Instance);
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