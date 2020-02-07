using System;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class ToExistsWaitStrategy : WaitStrategy
    {
        public ToExistsWaitStrategy(int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval)
        {
            TimeoutInterval = timeoutInterval;
        }

        public override void WaitUntil(IWebDriver driver, By by)
        {
            WaitUntil(ElementExists(driver, by), driver, TimeoutInterval, SleepInterval);
        }

        private Func<IWebDriver, bool> ElementExists(ISearchContext searchContext, By by)
        {
            return driver =>
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
