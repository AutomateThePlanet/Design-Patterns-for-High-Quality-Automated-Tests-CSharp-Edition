namespace ApiUsabilityDemos.Seventh
{
    public abstract class NavigatableEShopPage : EShopPage
    {
        protected readonly INavigationService _navigationService;

        protected NavigatableEShopPage(IElementFindService findService, INavigationService navigationService)
             : base(findService)
        {
            _navigationService = navigationService;
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
