using System;
using System.Collections.Generic;
using System.Threading;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExtensibilityDemos
{
    public class WebElement : Element
    {
        private IWebDriver _webDriver;
        private IWebElement _webElement;
        private NativeElementFinderService _nativeElementFinderService;
        private By _by;

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            _webDriver = webDriver;
            _webElement = webElement;
            _by = by;
            _nativeElementFinderService = new NativeElementFinderService(webElement);
        }

        public override By By
        {
            get
            {
                return _by;
            }
        }

        public override string Text
        {
            get
            {
                return _webElement?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                return _webElement?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                return _webElement?.Displayed;
            }
        }

        public override void Click()
        {
            WaitToBeClickable(By);
            _webElement?.Click();
        }

        public override List<Element> FindAllByClass(string cssClass)
        {
            var byStrategy = new ByClassStrategy(cssClass);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllById(string id)
        {
            var byStrategy = new ByIdStrategy(id);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByTag(string tag)
        {
            var byStrategy = new ByTagStrategy(tag);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByCss(string css)
        {
            var byStrategy = new ByCssStrategy(css);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByLinkText(string linkText)
        {
            var byStrategy = new ByLinkTextStrategy(linkText);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()));
            }
            return resultElements;
        }

        public override List<Element> FindAllByXPath(string xpath)
        {
            var byStrategy = new ByXPathStrategy(xpath);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<Element>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()));
            }
            return resultElements;
        }

        public override Element FindByClass(string cssClass)
        {
            var byStrategy = new ByClassStrategy(cssClass);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindById(string id)
        {
            var byStrategy = new ByIdStrategy(id);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByTag(string tag)
        {
            var byStrategy = new ByTagStrategy(tag);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByXPath(string xpath)
        {
            var byStrategy = new ByXPathStrategy(xpath);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByCss(string css)
        {
            var byStrategy = new ByCssStrategy(css);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        public override Element FindByLinkText(string linkText)
        {
            var byStrategy = new ByLinkTextStrategy(linkText);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert());
        }

        ////public override Element FindElement(By locator)
        ////{
        ////    return new WebElement(_webDriver, _webElement?.FindElement(locator), locator);
        ////}

        public override string GetAttribute(string attributeName)
        {
            return _webElement?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Thread.Sleep(500);
            _webElement?.Clear();
            _webElement?.SendKeys(text);
        }

        public override void WaitToExists(int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(WebDriverException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By));
            }
        }

        private void WaitToBeClickable(By by, int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(WebDriverException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
        }

        public override List<TElement> FindAll<TByStrategy, TElement>(string value)
        {
            var byStrategy = (TByStrategy)Activator.CreateInstance(typeof(TByStrategy), value);
            var nativeElements = _nativeElementFinderService.FindAll(byStrategy);
            var resultElements = new List<TElement>();
            foreach (var nativeElement in nativeElements)
            {
                resultElements.Add(new WebElement(_webDriver, nativeElement, byStrategy.Convert()) as TElement);
            }
            return resultElements;
        }

        public override TElement Find<TByStrategy, TElement>(string value)
        {
            var byStrategy = (TByStrategy)Activator.CreateInstance(typeof(TByStrategy), value);
            var nativeElement = _nativeElementFinderService.Find(byStrategy);
            return new WebElement(_webDriver, nativeElement, byStrategy.Convert()) as TElement;
        }
    }
}
