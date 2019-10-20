using System;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExtensibilityDemos
{
    public abstract class WaitStrategy
    {
        protected WaitStrategy(int? timeoutInterval = null, int? sleepInterval = null)
        {
            TimeoutInterval = timeoutInterval;
            SleepInterval = sleepInterval;
        }

        protected int? TimeoutInterval { get; set; }

        protected int? SleepInterval { get; }

        public abstract void WaitUntil(IWebDriver driver, By by);

        protected void WaitUntil(Func<IWebDriver, bool> waitCondition, IWebDriver driver, int? timeout, int? sleepInterval)
        {
            if (timeout != null && sleepInterval != null)
            {
                var timeoutTimeSpan = TimeSpan.FromSeconds((int)timeout);
                var sleepIntervalTimeSpan = TimeSpan.FromSeconds((int)sleepInterval);
                var wait = new WebDriverWait(new SystemClock(), driver, timeoutTimeSpan, sleepIntervalTimeSpan);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                wait.Until(waitCondition);
            }
        }

        protected void WaitUntil(Func<IWebDriver, IWebElement> waitCondition, IWebDriver driver, int? timeout, int? sleepInterval)
        {
            if (timeout != null && sleepInterval != null)
            {
                var timeoutTimeSpan = TimeSpan.FromSeconds((int)timeout);
                var sleepIntervalTimeSpan = TimeSpan.FromSeconds((int)sleepInterval);
                var wait = new WebDriverWait(new SystemClock(), driver, timeoutTimeSpan, sleepIntervalTimeSpan);
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                wait.Until(waitCondition);
            }
        }

        protected IWebElement FindElement(ISearchContext searchContext, By by)
        {
            var nativeElementFinder = new NativeElementFinderService(searchContext);
            var element = nativeElementFinder.Find(by);
            return element;
        }
    }
}
