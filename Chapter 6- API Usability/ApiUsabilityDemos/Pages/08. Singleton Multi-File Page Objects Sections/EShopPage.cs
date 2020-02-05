namespace ApiUsabilityDemos.Eight
{
    public abstract class EShopPage<TPage>
        where TPage : EShopPage<TPage>, new()
    {
        private static TPage _instance;

        protected readonly IElementFindService ElementFindService;

        protected EShopPage()
        {
            ElementFindService = LoggingSingletonDriver.Instance;
            SearchSection = new SearchSection(LoggingSingletonDriver.Instance);
            MainMenuSection = new MainMenuSection(LoggingSingletonDriver.Instance);
            CartInfoSection = new CartInfoSection(LoggingSingletonDriver.Instance);
        }

        public static TPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TPage();
                }

                return _instance;
            }
        }

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }
    }
}