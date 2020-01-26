namespace ApiUsabilityDemos.Eight
{
    public abstract class NavigatableEShopPage<TPage> : EShopPage<TPage>
        where TPage : NavigatableEShopPage<TPage>, new()
    {
        protected readonly INavigationService _navigationService;

        protected NavigatableEShopPage()
        {
            _navigationService = LoggingSingletonDriver.Instance;
        }

        protected abstract string Url { get; }

        public void Open()
        {
            _navigationService.GoToUrl(Url);
            WaitForPageLoad();
        }

        protected abstract void WaitForPageLoad();
    }
}
