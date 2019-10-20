namespace ApiUsabilityDemos.Eight
{
    public abstract class NavigatableEShopPage<T>
        where T : NavigatableEShopPage<T>, new()
    {
        private static T instance;
        protected readonly INavigationService _navigationService;

        protected NavigatableEShopPage()
        {
            _navigationService = LoggingSingletonDriver.Instance;
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

        protected abstract string Url { get; }

        public void Open()
        {
            _navigationService.GoToUrl(Url);
            WaitForElementToDisplay();
        }

        protected abstract void WaitForElementToDisplay();
    }
}
