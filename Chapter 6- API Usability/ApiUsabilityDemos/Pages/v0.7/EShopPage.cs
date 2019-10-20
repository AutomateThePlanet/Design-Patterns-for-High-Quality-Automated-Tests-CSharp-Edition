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

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }
    }
}
