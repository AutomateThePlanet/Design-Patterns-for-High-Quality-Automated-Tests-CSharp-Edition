using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace BenchmarkingDemos
{
    public class WebDriver : Driver
    {
        private IWebDriver _webDriver;
        private WebDriverWait _webDriverWait;

        public override Uri Url => new Uri(_webDriver.Url);

        public override void Start(Browser browser)
        {
            string executionFolder = DriverExecutablePathResolver.GetDriverExecutablePath();
            switch (browser)
            {
                case Browser.Chrome:
                    _webDriver = new ChromeDriver(executionFolder);
                    break;
                case Browser.Firefox:
                    _webDriver = new FirefoxDriver(executionFolder);
                    break;
                case Browser.Edge:
                    _webDriver = new EdgeDriver(executionFolder);
                    break;
                case Browser.Opera:
                    _webDriver = new OperaDriver(executionFolder);
                    break;
                case Browser.Safari:
                    _webDriver = new SafariDriver(executionFolder);
                    break;
                case Browser.InternetExplorer:
                    _webDriver = new InternetExplorerDriver(executionFolder);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
            }

            _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
        }

        public override void Quit()
        {
            _webDriver.Quit();
        }

        public override void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            IWebElement nativeWebElement = 
                _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
            Element element = new WebElement(_webDriver, nativeWebElement, locator);

            // If we use log decorator.
            Element logElement = new LogElement(element);

            return logElement;
        }

        public override List<Element> FindElements(By locator)
        {
            ReadOnlyCollection<IWebElement> nativeWebElements = 
                _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
            var elements = new List<Element>();
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

        public override void WaitUntilPageLoadsCompletely()
        {
            var js = (IJavaScriptExecutor)_webDriver;
            _webDriverWait.Until(wd => js.ExecuteScript("return document.readyState").ToString() == "complete");
        }
    }
}
