using System;
using System.Linq;
using System.Reflection;
using ApiUsabilityDemos.Ninth;

namespace ApiUsabilityDemos.Pages.Ninth
{
    public class App : IDisposable
    {
        private readonly Driver _driver;

        public App(Browser browserType = Browser.Chrome)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(browserType);
            BrowserService = _driver;
            CookiesService = _driver;
            DialogService = _driver;
        }

        public void Dispose() => _driver.Quit();

        public IBrowserService BrowserService { get; }
        public ICookiesService CookiesService { get; }
        public IDialogService DialogService { get; }

        public TPage Create<TPage>()
            where TPage : EShopPage
        {
            var constructor = typeof(TPage).GetTypeInfo().GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var page = constructor?.Invoke(new object[] { _driver }) as TPage;
            return page;
        }

        public TPage GoTo<TPage>()
            where TPage : NavigatableEShopPage
        {
            var constructor = typeof(TPage).GetTypeInfo().GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var page = constructor?.Invoke(new object[] { _driver }) as TPage;
            page?.Open();

            return page;
        }
    }
}
