namespace AssessmentSystemDemos.Facades.First
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(Driver driver) : base(driver)
        {
            MainPageElements = new MainPageElements(driver);
            MainPageAssertions = new MainPageAssertions(MainPageElements);
        }

        public MainPageElements MainPageElements { get; set; }
        public MainPageAssertions MainPageAssertions { get; set; }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart(string rocketName)
        {
            Open();
            MainPageElements.GetProductBoxByName(rocketName).Click();
            Driver.WaitForAjax();
            MainPageElements.ViewCartButton.Click();
        }

        protected override void WaitForElementToDisplay()
        {
            MainPageElements.AddToCartFalcon9.WaitToExists();
        }
    }
}