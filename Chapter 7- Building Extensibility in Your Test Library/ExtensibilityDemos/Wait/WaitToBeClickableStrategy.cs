using System;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class WaitToBeClickableStrategy : WaitStrategy
    {
        public WaitToBeClickableStrategy(int? timeoutInterval = null, int? sleepInterval = null)
            : base(timeoutInterval, sleepInterval)
        {
            TimeoutInterval = timeoutInterval;
        }

        public override void WaitUntil(IWebDriver driver, By by)
        {
            WaitUntil(ElementIsClickable(driver, by), driver, TimeoutInterval, SleepInterval);
        }

        private Func<IWebDriver, bool> ElementIsClickable(ISearchContext searchContext, By by)
        {
            return driver =>
            {
                var element = FindElement(searchContext, by);
                try
                {
                    return element != null && element.Enabled;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
            };
        }
    }
}
