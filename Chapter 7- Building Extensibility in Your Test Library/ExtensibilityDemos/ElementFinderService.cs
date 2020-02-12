using System.Collections.Generic;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class ElementFinderService
    {
        private readonly ISearchContext _searchContext;
        private readonly IWebDriver _driver;

        public ElementFinderService(ISearchContext searchContext, IWebDriver driver)
        {
            _searchContext = searchContext;
            _driver = driver;
        }

        public IWebElement Find(FindStrategy findStrategy)
        {
            Wait.To.Exists().WaitUntil(_searchContext, _driver, findStrategy.Convert());
            var element = _searchContext.FindElement(findStrategy.Convert());
            return element;
        }

        public IWebElement Find(By by)
        {
            Wait.To.Exists().WaitUntil(_searchContext, _driver, by);
            var element = _searchContext.FindElement(by);
            return element;
        }

        public IEnumerable<IWebElement> FindAll(By by)
        {
            Wait.To.Exists().WaitUntil(_searchContext, _driver, by);
            IEnumerable<IWebElement> result = _searchContext.FindElements(by);
            return result;
        }

        public IEnumerable<IWebElement> FindAll(FindStrategy findStrategy)
        {
            new ToExistsWaitStrategy().WaitUntil(_searchContext, _driver, findStrategy.Convert());
            IEnumerable<IWebElement> result = _searchContext.FindElements(findStrategy.Convert());
            return result;
        }
    }
}
