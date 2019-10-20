using System;
using System.Linq;
using System.Reflection;
using ExtensibilityDemos.Tenth;

namespace ExtensibilityDemos.Pages.Tenth
{
    public class App : IDisposable
    {
        private Driver _driver;

        public App(Browser browserType = Browser.Chrome)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(browserType);
            WaitService = _driver;
            BrowserService = _driver;
            CookiesService = _driver;
        }

        public void Dispose() => _driver.Quit();

        public IElementWaitService WaitService { get; set; }
        public IBrowserService BrowserService { get; set; }
        public ICookiesService CookiesService { get; set; }

        public TPage Create<TPage>()
            where TPage : EShopPage
        {
            var constructor = typeof(TPage).GetTypeInfo().GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var page = constructor.Invoke(new object[] { _driver }) as TPage;
            return page;
        }

        public TPage GoTo<TPage>()
            where TPage : NavigatableEShopPage
        {
            var constructor = typeof(TPage).GetTypeInfo().GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var page = constructor.Invoke(new object[] { _driver }) as TPage;
            page.Open();

            return page;
        }
    }
}
