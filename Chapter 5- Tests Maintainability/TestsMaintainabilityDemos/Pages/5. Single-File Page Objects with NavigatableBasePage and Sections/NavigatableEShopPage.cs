namespace TestsMaintainabilityDemos.Fifth
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

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }

        protected abstract string Url { get; }

        public void Open()
        {
            Driver.GoToUrl(Url);
            WaitForElementToBeDisplayed();
        }

        protected abstract void WaitForElementToBeDisplayed();
    }
}
