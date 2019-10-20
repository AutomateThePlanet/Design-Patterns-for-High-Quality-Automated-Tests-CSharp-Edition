using System.Collections.Generic;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public abstract class Element 
    {
        public abstract By By { get; }
        public abstract string Text { get; }
        public abstract bool? Enabled { get; }
        public abstract bool? Displayed { get; }
        public abstract void TypeText(string text);
        public abstract void Click();
        public abstract string GetAttribute(string attributeName);
        public abstract void WaitToExists(int timeoutInSeconds = 30);
        ////public abstract Element FindElement(By locator);

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
    }
}
