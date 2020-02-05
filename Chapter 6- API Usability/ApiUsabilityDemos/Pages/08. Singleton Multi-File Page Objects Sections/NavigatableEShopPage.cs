namespace ApiUsabilityDemos.Eight
{
    public abstract class NavigatableEShopPage<T>
        where T : NavigatableEShopPage<T>, new()
    {
        private static T _instance;
        protected readonly INavigationService NavigationService;

        protected NavigatableEShopPage()
        {
            NavigationService = LoggingSingletonDriver.Instance;
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

        protected abstract string Url { get; }

        public void Open()
        {
            NavigationService.GoToUrl(Url);
            WaitForElementToDisplay();
        }

        protected abstract void WaitForElementToDisplay();
    }
}
