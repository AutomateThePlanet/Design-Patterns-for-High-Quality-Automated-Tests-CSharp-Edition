using System.Collections.Generic;
using OpenQA.Selenium;

namespace StabilizeTestsDemos.SixthVersion
{
    public class DriverDecorator : Driver
    {
        protected Driver driver;

        public DriverDecorator(Driver driver)
        {
            this.driver = driver;
        }

        public override void Start(Browser browser)
        {
            driver?.Start(browser);
        }

        public override void Quit()
        {
            driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            return driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            return driver?.FindElements(locator);
        }

        public override void WaitForAjax()
        {
            driver?.WaitForAjax();
        }

        public override void WaitForJavaScriptAnimations()
        {
            driver?.WaitForJavaScriptAnimations();
        }

        public override void WaitUntilPageLoadsCompletely()
        {
            driver?.WaitUntilPageLoadsCompletely();
        }

        public override void DeleteAllCookies()
        {
            driver?.DeleteAllCookies();
        }
    }
}
