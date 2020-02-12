using System;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class ToExistsWaitStrategy : WaitStrategy
    {
        public ToExistsWaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
            : base(timeoutIntervalInSeconds, sleepIntervalInSeconds)
        {
        }

        public override void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by)
        {
            WaitUntil(ElementExists(searchContext, by), driver);
        }

        private Func<ISearchContext, bool> ElementExists(ISearchContext searchContext, By by)
        {
            return _ =>
            {
                try
                {
                    var element = FindElement(searchContext, by);
                    return element != null;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            };
        }
    }
}
