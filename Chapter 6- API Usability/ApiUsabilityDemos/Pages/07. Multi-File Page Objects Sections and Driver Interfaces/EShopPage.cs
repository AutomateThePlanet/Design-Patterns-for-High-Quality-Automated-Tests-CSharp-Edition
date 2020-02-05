namespace ApiUsabilityDemos.Seventh
{
    public abstract class EShopPage
    {
        protected readonly IElementFindService ElementFindService;

        protected EShopPage(IElementFindService elementFindService)
        {
            ElementFindService = elementFindService;
            SearchSection = new SearchSection(elementFindService);
            MainMenuSection = new MainMenuSection(elementFindService);
            CartInfoSection = new CartInfoSection(elementFindService);
        }

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }
    }
}
