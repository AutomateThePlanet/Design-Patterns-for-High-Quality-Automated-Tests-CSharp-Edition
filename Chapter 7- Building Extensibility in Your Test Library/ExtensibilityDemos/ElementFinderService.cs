using System.Collections.Generic;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class ElementFinderService
    {
        private readonly ISearchContext _searchContext;

        public ElementFinderService(ISearchContext searchContext)
        {
            _searchContext = searchContext;
        }

        public IWebElement Find<TFindStrategy>(TFindStrategy by)
            where TFindStrategy : FindStrategy
        {
            var element = _searchContext.FindElement(by.Convert());
            return element;
        }

        public IWebElement Find(By by)
        {
            var element = _searchContext.FindElement(by);
            return element;
        }

        public IEnumerable<IWebElement> FindAll(By by)
        {
            IEnumerable<IWebElement> result = _searchContext.FindElements(by);
            return result;
        }

        public IEnumerable<IWebElement> FindAll<TFindStrategy>(TFindStrategy by)
            where TFindStrategy : FindStrategy
        {
            IEnumerable<IWebElement> result = _searchContext.FindElements(@by.Convert());
            return result;
        }}

}
