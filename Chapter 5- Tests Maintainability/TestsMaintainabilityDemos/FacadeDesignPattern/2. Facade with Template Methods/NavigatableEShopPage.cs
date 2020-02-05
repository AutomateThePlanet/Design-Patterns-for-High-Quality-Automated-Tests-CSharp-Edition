namespace TestsMaintainabilityDemos.Facades.Second
{
    public abstract class NavigatableEShopPage : EShopPage
    {
        protected NavigatableEShopPage(Driver driver)
        : base(driver)
        {
        }

        protected abstract string Url { get; }

        public void Open()
        {
            Driver.GoToUrl(Url);
            WaitForPageLoad();
        }

        protected abstract void WaitForPageLoad();
    }
}
