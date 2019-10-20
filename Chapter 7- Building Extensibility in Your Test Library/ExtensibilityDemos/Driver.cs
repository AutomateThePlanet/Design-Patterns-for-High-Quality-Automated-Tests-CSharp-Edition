using System;
using System.Collections.Generic;
using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos
{
    public abstract class Driver : IDriver
    {
        public abstract Uri Url { get; }
        public abstract void Start(Browser browser);
        public abstract void Quit();
        public abstract void GoToUrl(string url);
        public abstract void WaitForAjax();
        public abstract void WaitForJavaScriptAnimations();
        public abstract void WaitUntilPageLoadsCompletely();

        public abstract Element FindById(string id);
        public abstract Element FindByXPath(string xpath);
        public abstract Element FindByTag(string tag);
        public abstract Element FindByClass(string cssClass);
        public abstract Element FindByCss(string css);
        public abstract Element FindByLinkText(string linkText);
        public abstract List<Element> FindAllById(string id);
        public abstract List<Element> FindAllByXPath(string xpath);
        public abstract List<Element> FindAllByTag(string tag);
        public abstract List<Element> FindAllByClass(string cssClass);
        public abstract List<Element> FindAllByCss(string css);
        public abstract List<Element> FindAllByLinkText(string linkText);
        public abstract List<TElement> FindAll<TByStrategy, TElement>(string value)
            where TByStrategy : ByStrategy
            where TElement : Element;
        public abstract TElement Find<TByStrategy, TElement>(string value)
            where TByStrategy : ByStrategy
            where TElement : Element;
        public abstract void Wait<TWaitStrategy, TElement>(TElement element, TWaitStrategy waitStrategy)
            where TWaitStrategy : WaitStrategy
            where TElement : Element;

        ////public abstract Element FindElement(By locator);
        ////public abstract List<Element> FindElements(By locator);
    }
}
