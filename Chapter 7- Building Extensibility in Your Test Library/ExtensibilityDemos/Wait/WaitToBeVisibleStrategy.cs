using System;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class WaitToBeVisibleStrategy : WaitStrategy
    {
        public WaitToBeVisibleStrategy(int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval)
        {
            TimeoutInterval = timeoutInterval;
        }

        public override void WaitUntil(IWebDriver driver, By by)
        {
            WaitUntil(ElementIsVisible(driver, by), driver, TimeoutInterval, SleepInterval);
        }

        private Func<IWebDriver, bool> ElementIsVisible(ISearchContext searchContext, By by)
        {
            return driver =>
            {
                try
                {
                    var element = FindElement(searchContext, by);
                    return element != null && element.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }
    }
}
