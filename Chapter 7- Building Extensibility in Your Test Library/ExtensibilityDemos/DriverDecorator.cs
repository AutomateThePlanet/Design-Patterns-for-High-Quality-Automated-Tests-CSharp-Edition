using System;
using System.Collections.Generic;

namespace ExtensibilityDemos
{
    public class DriverDecorator : Driver
    {
        protected Driver driver;

        public DriverDecorator(Driver driver)
        {
            this.driver = driver;
        }

        public override Uri Url => driver?.Url;

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

        ////public override Element FindElement(By locator)
        ////{
        ////    return driver?.FindElement(locator);
        ////}

        ////public override List<Element> FindElements(By locator)
        ////{
        ////    return driver?.FindElements(locator);
        ////}

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

        public override Element FindById(string id) => driver?.FindById(id);
        public override Element FindByXPath(string xpath) => driver?.FindByXPath(xpath);
        public override Element FindByTag(string tag) => driver?.FindByTag(tag);
        public override Element FindByClass(string cssClass) => driver?.FindByClass(cssClass);
        public override Element FindByCss(string css) => driver?.FindByCss(css);
        public override Element FindByLinkText(string linkText) => driver?.FindByLinkText(linkText);
        public override List<Element> FindAllById(string id) => driver?.FindAllById(id);
        public override List<Element> FindAllByXPath(string xpath) => driver?.FindAllByXPath(xpath);
        public override List<Element> FindAllByTag(string tag) => driver?.FindAllByTag(tag);
        public override List<Element> FindAllByClass(string cssClass) => driver?.FindAllByClass(cssClass);
        public override List<Element> FindAllByCss(string css) => driver?.FindAllByCss(css);
        public override List<Element> FindAllByLinkText(string linkText) => driver?.FindAllByLinkText(linkText);
        public override List<TElement> FindAll<TByStrategy, TElement>(string value) => driver?.FindAll<TByStrategy, TElement>(value);
        public override TElement Find<TByStrategy, TElement>(string value) => driver?.Find<TByStrategy, TElement>(value);
        public override void Wait<TWaitStrategy, TElement>(TElement element, TWaitStrategy waitStrategy) => driver?.Wait(element, waitStrategy);
    }
}