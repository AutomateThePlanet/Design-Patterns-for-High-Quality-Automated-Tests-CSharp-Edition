namespace ApiUsabilityDemos.Eight
{
    public abstract class EShopPage<TPage>
        where TPage : EShopPage<TPage>, new()
    {
        private static TPage instance;

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
                if (instance == null)
                {
                    instance = new TPage();
                }

                return instance;
            }
        }

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }
    }
}