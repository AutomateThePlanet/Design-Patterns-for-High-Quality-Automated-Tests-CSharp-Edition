namespace TestDataPreparationDemos.Tenth
{
    public abstract class NavigatableEShopPage : EShopPage
    {
        protected NavigatableEShopPage(Driver driver)
        : base(driver)
        {
        }

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }

        protected abstract string Url { get; }

        public void Open()
        {
            Driver.GoToUrl(Url);
            WaitForPageLoad();
        }

        protected abstract void WaitForPageLoad();
    }
}
