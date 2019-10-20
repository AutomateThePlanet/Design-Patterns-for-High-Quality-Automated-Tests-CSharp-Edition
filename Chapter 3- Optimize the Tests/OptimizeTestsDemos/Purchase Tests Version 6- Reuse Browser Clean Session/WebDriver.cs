using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace StabilizeTestsDemos.SixthVersion
{
    public class WebDriver : Driver
    {
        private IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;

        public override void Start(Browser browser)
        {
            switch (browser)
            {
                case Browser.Chrome:
                    _webDriver = new ChromeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Firefox:
                    _webDriver = new FirefoxDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Edge:
                    _webDriver = new EdgeDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Opera:
                    _webDriver = new OperaDriver(Environment.CurrentDirectory);
                    break;
                case Browser.Safari:
                    _webDriver = new SafariDriver(Environment.CurrentDirectory);
                    break;
                case Browser.InternetExplorer:
                    _webDriver = new InternetExplorerDriver(Environment.CurrentDirectory);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            _webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _webDriverWait.IgnoreExceptionTypes(typeof(WebDriverException));
        }

        public override void Quit()
        {
            _webDriver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            IWebElement nativeWebElement = _webDriverWait.Until(drv => drv.FindElement(locator));
            Element element = new WebElement(_webDriver, nativeWebElement, locator);

            // If we use log decorator.
            LogElement logElement = new LogElement(element);

            return logElement;
        }

        public override List<Element> FindElements(By locator)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(drv => drv.FindElements(locator));
            List<Element> elements = new List<Element>();
            foreach (var nativeWebElement in nativeWebElements)
            {
                Element element = new WebElement(_webDriver, nativeWebElement, locator);
                elements.Add(element);
            }

            return elements;
        }

        public override void WaitForAjax()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("return jQuery.active").ToString() == "0");
        }

        public override void WaitForJavaScriptAnimations()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("jQuery(':animated').length").ToString() == "0");
        }

        public override void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }

        public override void DeleteAllCookies()
        {
            _webDriver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
