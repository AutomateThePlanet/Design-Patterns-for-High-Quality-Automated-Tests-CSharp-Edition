using System.Collections.Generic;
using OpenQA.Selenium;

namespace StabilizeTestsDemos.SixthVersion
{
    public class DriverDecorator : Driver
    {
        protected readonly Driver Driver;

        public DriverDecorator(Driver driver)
        {
            Driver = driver;
        }

        public override void Start(Browser browser)
        {
            Driver?.Start(browser);
        }

        public override void Quit()
        {
            Driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            return Driver?.FindElements(locator);
        }

        public override void WaitForAjax()
        {
            Driver?.WaitForAjax();
        }

        public override void WaitForJavaScriptAnimations()
        {
            Driver?.WaitForJavaScriptAnimations();
        }

        public override void WaitUntilPageLoadsCompletely()
        {
            Driver?.WaitUntilPageLoadsCompletely();
        }

        public override void DeleteAllCookies()
        {
            Driver?.DeleteAllCookies();
        }
    }
}
