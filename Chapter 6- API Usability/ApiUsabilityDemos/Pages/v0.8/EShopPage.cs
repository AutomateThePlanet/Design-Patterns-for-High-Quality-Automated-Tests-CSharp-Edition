namespace ApiUsabilityDemos.Eight
{
    public abstract class EShopPage<T>
        where T : EShopPage<T>, new()
    {
        private static T instance;

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
                if (instance == null)
                {
                    instance = new T();
                }

                return instance;
            }
        }

        public SearchSection SearchSection { get; set; }
        public MainMenuSection MainMenuSection { get; set; }
        public CartInfoSection CartInfoSection { get; set; }
    }
}
