using System;
using System.Linq;
using System.Reflection;
using ApiUsabilityDemos.Tenth;

namespace ApiUsabilityDemos.Pages.Tenth
{
    public class App : IDisposable
    {
        private Driver _driver;

        public App(Browser browserType = Browser.Chrome)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(browserType);
        }

        public void Dispose() => _driver.Quit();


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
