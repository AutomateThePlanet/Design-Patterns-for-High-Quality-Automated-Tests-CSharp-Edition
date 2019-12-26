namespace TestDataPreparationDemos.Facades.Second
{
    public abstract class NavigatableEShopPage
    {
        protected readonly Driver Driver;

        protected NavigatableEShopPage(Driver driver)
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
            WaitForElementToDisplay();
        }

        protected abstract void WaitForElementToDisplay();
    }
}
