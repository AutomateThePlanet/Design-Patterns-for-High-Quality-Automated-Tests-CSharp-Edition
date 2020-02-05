namespace ApiUsabilityDemos.Eight
{
    public abstract class NavigatableEShopPage<TPage> : EShopPage<TPage>
        where TPage : NavigatableEShopPage<TPage>, new()
    {
        protected readonly INavigationService NavigationService;

        protected NavigatableEShopPage()
        {
            NavigationService = LoggingSingletonDriver.Instance;
        }

        protected abstract string Url { get; }

        public void Open()
        {
            NavigationService.GoToUrl(Url);
            WaitForPageLoad();
        }

        protected abstract void WaitForPageLoad();
    }
}
