namespace TestDataPreparationDemos.Facades.Second
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(Driver driver) 
            : base(driver)
        {
            Elements = new MainPageElements(driver);
            Assertions = new MainPageAssertions(Elements);
        }

        public MainPageElements Elements { get; }
        public MainPageAssertions Assertions { get; }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart(string rocketName)
        {
            Open();
            Elements.GetProductBoxByName(rocketName).Click();
            Driver.WaitForAjax();
            Elements.ViewCartButton.Click();
        }

        protected override void WaitForPageLoad()
        {
            Elements.AddToCartFalcon9.WaitToExists();
        }
    }
}