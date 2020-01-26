namespace TestDataPreparationDemos.Tenth
{
    public abstract class EShopPage
    {
        protected Driver Driver;

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }

        internal void SetDriver(Driver driver)
        {
            Driver = driver;
            SearchSection = new SearchSection(driver);
            MainMenuSection = new MainMenuSection(driver);
            CartInfoSection = new CartInfoSection(driver);
        }
    }
}
