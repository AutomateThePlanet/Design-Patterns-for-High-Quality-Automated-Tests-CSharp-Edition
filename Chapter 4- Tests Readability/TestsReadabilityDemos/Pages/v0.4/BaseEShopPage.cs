namespace TestsReadabilityDemos.Fourth
{
    public abstract class BaseEShopPage
    {
        protected readonly Driver Driver;

        public BaseEShopPage(Driver driver)
        {
            Driver = driver;
            SearchSection = new SearchSection(driver);
            MainMenuSection = new MainMenuSection(driver);
            CartInfoSection = new CartInfoSection(driver);
        }

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }

        protected abstract string Url { get; }

        public void Open()
        {
            Driver.GoToUrl(Url);
        }
    }
}
