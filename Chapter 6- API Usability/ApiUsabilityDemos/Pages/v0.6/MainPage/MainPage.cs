namespace ApiUsabilityDemos.Sixth
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(Driver driver) 
            : base(driver)
        {
            Elements = new MainPageElements(driver);
            Assertions = new MainPageAssertions(Elements);
        }

        public MainPageElements Elements { get; set; }
        public MainPageAssertions Assertions { get; set; }

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