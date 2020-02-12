using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExtensibilityDemos
{
    public abstract class WaitStrategy
    {
        protected WaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
        {
            TimeoutInterval = TimeSpan.FromSeconds(timeoutIntervalInSeconds ?? 30);
            SleepInterval = TimeSpan.FromSeconds(sleepIntervalInSeconds ?? 2);
        }

        protected TimeSpan TimeoutInterval { get; }

        protected TimeSpan SleepInterval { get; }

        public abstract void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by);

        protected void WaitUntil(Func<ISearchContext, bool> waitCondition, IWebDriver driver)
        {
            var webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeoutInterval, SleepInterval);
            webDriverWait.Until(waitCondition);
        }

        protected void WaitUntil(Func<ISearchContext, IWebElement> waitCondition, IWebDriver driver)
        {
            var webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeoutInterval, SleepInterval);
            webDriverWait.Until(waitCondition);
        }

        protected IWebElement FindElement(ISearchContext searchContext, By by)
        {
            var element = searchContext.FindElement(by);
            return element;
        }
    }
}
