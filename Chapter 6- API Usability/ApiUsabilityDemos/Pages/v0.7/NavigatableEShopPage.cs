namespace ApiUsabilityDemos.Seventh
{
    public abstract class NavigatableEShopPage
    {
        protected readonly INavigationService _navigationService;

        protected NavigatableEShopPage(IElementFindService findService, INavigationService navigationService)
        {
            _navigationService = navigationService;
            SearchSection = new SearchSection(findService);
            MainMenuSection = new MainMenuSection(findService);
            CartInfoSection = new CartInfoSection(findService);
        }

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }

        protected abstract string Url { get; }

        public void Open()
        {
            _navigationService.GoToUrl(Url);
            WaitForElementToDisplay();
        }

        protected abstract void WaitForElementToDisplay();
    }
}
