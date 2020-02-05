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
            _webDriverWait.IgnoreExceptionTypes(typeof(WebDriverException));
            _webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            _webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            _elementFinderService = new ElementFinderService(_webDriver);

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
        ////    IWebElement nativeWebElement = _webDriverWait.Until(drv => drv.FindElement(locator));
        ////    Element Element = new WebElement(_webDriver, nativeWebElement, locator);

        ////    // If we use log decorator.
        ////    LogElement logElement = new LogElement(Element);

        ////    return logElement;
        ////}

        ////public override List<Element> FindElements(By locator)
        ////{
        ////    ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(drv => drv.FindElements(locator));
        ////    List<Element> elements = new List<Element>();
        ////    foreach (var nativeWebElement in nativeWebElements)
        ////    {
        ////        Element Element = new WebElement(_webDriver, nativeWebElement, locator);
        ////        elements.Add(Element);
        ////    }

        ////    return elements;
        ////}

        public override List<Element> FindAllByClass(string cssClass)
        {
            return FindAll<ByClassStrategy, Element>(new ByClassStrategy(cssClass));
        }

        public override List<Element> FindAllById(string id)
        {
            return FindAll<ByIdStrategy, Element>(new ByIdStrategy(id));
        }

        public override List<Element> FindAllByTag(string tag)
        {
            return FindAll<ByTagStrategy, Element>(new ByTagStrategy(tag));
        }

        public override List<Element> FindAllByXPath(string xpath)
        {
            return FindAll<ByXPathStrategy, Element>(new ByXPathStrategy(xpath));
        }

        public override List<Element> FindAllByCss(string css)
        {
            return FindAll<ByCssStrategy, Element>(new ByCssStrategy(css));
        }

        public override List<Element> FindAllByLinkText(string linkText)
        {
            return FindAll<ByLinkTextStrategy, Element>(new ByLinkTextStrategy(linkText));
        }

        public override Element FindByCss(string css)
        {
            return Find<ByCssStrategy, Element>(new ByCssStrategy(css));
        }

        public override Element FindByLinkText(string linkText)
        {
            return Find<ByLinkTextStrategy, Element>(new ByLinkTextStrategy(linkText));
        }

        public override Element FindByClass(string cssClass)
        {
            return Find<ByClassStrategy, Element>(new ByClassStrategy(cssClass));
        }

        public override Element FindById(string id)
        {
            return Find<ByIdStrategy, Element>(new ByIdStrategy(id));
        }

        public override Element FindByTag(string tag)
        {
            return Find<ByTagStrategy, Element>(new ByTagStrategy(tag));
        }

        public override Element FindByXPath(string xpath)
        {
            return Find<ByXPathStrategy, Element>(new ByXPathStrategy(xpath));
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

        public override List<TElement> FindAll<TFindStrategy, TElement>(TFindStrategy findStrategy)
        {
            var nativeElements = _elementFinderService.FindAll(findStrategy);
            var resultElements = new List<TElement>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, findStrategy.Convert()) as TElement);
            }
            return resultElements;
        }

        public override TElement Find<TFindStrategy, TElement>(TFindStrategy findStrategy)
        {
            var nativeElement = _elementFinderService.Find(findStrategy);
            return new WebElement(_webDriver, nativeElement, findStrategy.Convert()) as TElement;
        }

        public override void Wait<TWaitStrategy, TElement>(TElement element, TWaitStrategy waitStrategy)
        {
            waitStrategy?.WaitUntil(_webDriver, element.By);
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
            Console.WriteLine(e.Element);
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
