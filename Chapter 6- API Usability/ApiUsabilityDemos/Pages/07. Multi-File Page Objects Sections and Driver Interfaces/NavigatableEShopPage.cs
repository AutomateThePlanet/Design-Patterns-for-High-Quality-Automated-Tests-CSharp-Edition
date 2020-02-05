namespace ApiUsabilityDemos.Seventh
{
    public abstract class NavigatableEShopPage
    {
        protected readonly INavigationService NavigationService;
        protected readonly IElementFindService FindService;

        protected NavigatableEShopPage(IElementFindService findService, INavigationService navigationService)
        {
            NavigationService = navigationService;
            FindService = findService;
            SearchSection = new SearchSection(findService);
            MainMenuSection = new MainMenuSection(findService);
            CartInfoSection = new CartInfoSection(findService);
        }

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }

        protected abstract string Url { get; }

        public void Open()
        {
            NavigationService.GoToUrl(Url);
            WaitForElementToDisplay();
        }

        protected abstract void WaitForElementToDisplay();
    }
}
