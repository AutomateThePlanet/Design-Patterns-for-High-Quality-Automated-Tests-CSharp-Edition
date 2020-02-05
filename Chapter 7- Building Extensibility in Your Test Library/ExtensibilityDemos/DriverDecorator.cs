using System;
using System.Collections.Generic;

namespace ExtensibilityDemos
{
    public abstract class DriverDecorator : Driver
    {
        protected Driver Driver;

        protected DriverDecorator(Driver driver)
        {
            Driver = driver;
        }

        public override Uri Url => Driver?.Url;

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

        ////public override Element FindElement(By locator)
        ////{
        ////    return Driver?.FindElement(locator);
        ////}

        ////public override List<Element> FindElements(By locator)
        ////{
        ////    return Driver?.FindElements(locator);
        ////}

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

        public override Element FindById(string id)
        {
            return Driver?.FindById(id);
        }

        public override Element FindByXPath(string xpath)
        {
            return Driver?.FindByXPath(xpath);
        }

        public override Element FindByTag(string tag)
        {
            return Driver?.FindByTag(tag);
        }

        public override Element FindByClass(string cssClass)
        {
            return Driver?.FindByClass(cssClass);
        }

        public override Element FindByCss(string css)
        {
            return Driver?.FindByCss(css);
        }

        public override Element FindByLinkText(string linkText)
        {
            return Driver?.FindByLinkText(linkText);
        }

        public override List<Element> FindAllById(string id)
        {
            return Driver?.FindAllById(id);
        }

        public override List<Element> FindAllByXPath(string xpath)
        {
            return Driver?.FindAllByXPath(xpath);
        }

        public override List<Element> FindAllByTag(string tag)
        {
            return Driver?.FindAllByTag(tag);
        }

        public override List<Element> FindAllByClass(string cssClass)
        {
            return Driver?.FindAllByClass(cssClass);
        }

        public override List<Element> FindAllByCss(string css)
        {
            return Driver?.FindAllByCss(css);
        }

        public override List<Element> FindAllByLinkText(string linkText)
        {
            return Driver?.FindAllByLinkText(linkText);
        }

        public override List<TElement> FindAll<TFindStrategy, TElement>(TFindStrategy findStrategy)
        {
            return Driver?.FindAll<TFindStrategy, TElement>(findStrategy);
        }

        public override TElement Find<TFindStrategy, TElement>(TFindStrategy findStrategy)
        {
            return Driver?.Find<TFindStrategy, TElement>(findStrategy);
        }

        public override void Wait<TWaitStrategy, TElement>(TElement element, TWaitStrategy waitStrategy)
        {
            Driver?.Wait(element, waitStrategy);
        }
    }
}