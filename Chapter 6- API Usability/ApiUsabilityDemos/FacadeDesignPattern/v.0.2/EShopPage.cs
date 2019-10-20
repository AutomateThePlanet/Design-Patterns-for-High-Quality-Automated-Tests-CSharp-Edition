namespace ApiUsabilityDemos.Facades.Second
{
    public abstract class EShopPage
    {
        protected readonly Driver Driver;

        protected EShopPage(Driver driver)
        {
            Driver = driver;
            SearchSection = new SearchSection(driver);
            MainMenuSection = new MainMenuSection(driver);
            CartInfoSection = new CartInfoSection(driver);
        }

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }
    }
}
