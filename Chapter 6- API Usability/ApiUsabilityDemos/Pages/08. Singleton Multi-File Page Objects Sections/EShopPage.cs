namespace ApiUsabilityDemos.Eight
{
    public abstract class EShopPage<T>
        where T : EShopPage<T>, new()
    {
        private static T _instance;

        protected readonly IElementFindService ElementFindService;

        protected EShopPage()
        {
            ElementFindService = LoggingSingletonDriver.Instance;
            SearchSection = new SearchSection(LoggingSingletonDriver.Instance);
            MainMenuSection = new MainMenuSection(LoggingSingletonDriver.Instance);
            CartInfoSection = new CartInfoSection(LoggingSingletonDriver.Instance);
        }

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new T();
                }

                return _instance;
            }
        }

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }
    }
}
