using System;
using System.Collections.Generic;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.UI;

namespace ExtensibilityDemos
{
    public class WebDriver : Driver
    {
        private readonly List<FiringWebDriverEventHandlers> _firingWebDriverEventHandlers;
        private IWebDriver _webDriver;
        private EventFiringWebDriver _eventFiringWebDriver;
        private WebDriverWait _webDriverWait;
        private ElementFinderService _elementFinderService;

        public WebDriver()
        {
            _firingWebDriverEventHandlers = new List<FiringWebDriverEventHandlers>
                                           {
                                               new DebugFiringWebDriverEventHandlers(),
                                               new LoggingFiringWebDriverEventHandlers()
                                           };
        }

        public override Uri Url => new Uri(_webDriver.Url);

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

            _elementFinderService = new ElementFinderService(_webDriver, _webDriver);

            // 1st version with private methods
            ////_eventFiringWebDriver = new EventFiringWebDriver(_webDriver);
            ////_eventFiringWebDriver.Navigated += OnNavigated;
            ////_eventFiringWebDriver.ExceptionThrown += OnExceptionThrown;
            ////_eventFiringWebDriver.ElementClicked += OnElementClicked;

            InitializeEventFiringWebDriver();
        }

        public override void Quit()
        {
            _webDriver.Quit();
        }

        public override void GoToUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }

        ////public override Element FindElement(By locator)
        ////{
        ////    IWebElement nativeWebElement = 
        ////        _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(locator));
        ////    Element element = new WebElement(_webDriver, nativeWebElement, locator);

        ////    // If we use log decorator.
        ////    Element logElement = new LogElement(element);

        ////    return logElement;
        ////}

        ////public override List<Element> FindElements(By locator)
        ////{
        ////    ReadOnlyCollection<IWebElement> nativeWebElements = 
        ////        _webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        ////    var elements = new List<Element>();
        ////    foreach (var nativeWebElement in nativeWebElements)
        ////    {
        ////        Element element = new WebElement(_webDriver, nativeWebElement, locator);
        ////        elements.Add(element);
        ////    }

        ////    return elements;
        ////}

        public override List<Element> FindAllByClass(string cssClass)
        {
            return FindAll(new ClassFindStrategy(cssClass));
        }

        public override List<Element> FindAllById(string id)
        {
            return FindAll(new IdFindStrategy(id));
        }

        public override List<Element> FindAllByTag(string tag)
        {
            return FindAll(new TagFindStrategy(tag));
        }

        public override List<Element> FindAllByXPath(string xpath)
        {
            return FindAll(new XPathFindStrategy(xpath));
        }

        public override List<Element> FindAllByCss(string css)
        {
            return FindAll(new CssFindStrategy(css));
        }

        public override List<Element> FindAllByLinkText(string linkText)
        {
            return FindAll(new LinkTextFindStrategy(linkText));
        }

        public override Element FindByCss(string css)
        {
            return Find(new CssFindStrategy(css));
        }

        public override Element FindByLinkText(string linkText)
        {
            return Find(new LinkTextFindStrategy(linkText));
        }

        public override Element FindByClass(string cssClass)
        {
            return Find(new ClassFindStrategy(cssClass));
        }

        public override Element FindById(string id)
        {
            return Find(new IdFindStrategy(id));
        }

        public override Element FindByTag(string tag)
        {
            return Find(new TagFindStrategy(tag));
        }

        public override Element FindByXPath(string xpath)
        {
            return Find(new XPathFindStrategy(xpath));
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

        public override Element Find(FindStrategy findStrategy)
        {
            var nativeElement = _elementFinderService.Find(findStrategy);
            return new WebElement(_webDriver, nativeElement, findStrategy.Convert());
        }

        public override List<Element> FindAll(FindStrategy findStrategy)
        {
            var nativeElements = _elementFinderService.FindAll(findStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, findStrategy.Convert()));
            }

            return resultElements;
        }

        public override void Wait(Element element, WaitStrategy waitStrategy)
        {
            waitStrategy?.WaitUntil(_webDriver, _webDriver, element.By);
        }

        private void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine(e.ThrownException.Message);
        }

        private void OnNavigated(object sender, WebDriverNavigationEventArgs e)
        {
            Console.WriteLine(e.Url);
        }

        private void OnElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine($"Element with tag = {e.Element.TagName} clicked.");
        }

        private void InitializeEventFiringWebDriver()
        {
            _eventFiringWebDriver = new EventFiringWebDriver(_webDriver);
            foreach (var webDriverEventHandler in _firingWebDriverEventHandlers)
            {
                _eventFiringWebDriver.Navigated += webDriverEventHandler.OnNavigated;
                _eventFiringWebDriver.ExceptionThrown += webDriverEventHandler.OnExceptionThrown;
                _eventFiringWebDriver.ElementClicked += webDriverEventHandler.OnElementClicked;
            }
        }
    }
}
