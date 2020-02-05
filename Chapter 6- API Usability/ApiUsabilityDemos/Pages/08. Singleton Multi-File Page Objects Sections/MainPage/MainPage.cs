namespace ApiUsabilityDemos.Eight
{
    public class MainPage : NavigatableEShopPage<MainPage>
    {
        public MainPage() 
        {
            Elements = new MainPageElements(LoggingSingletonDriver.Instance);
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

        protected override void WaitForElementToDisplay()
        {
            Elements.AddToCartFalcon9.WaitToExists();
        }
    }
}