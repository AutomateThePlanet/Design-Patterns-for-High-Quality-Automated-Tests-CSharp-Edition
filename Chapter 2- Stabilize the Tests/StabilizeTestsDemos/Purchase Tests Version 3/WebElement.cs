﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace StabilizeTestsDemos.ThirdVersion
{
    public class WebElement : Element
    {
        private IWebDriver _webDriver;
        private IWebElement _webElement;
        private By _by;

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            _webDriver = webDriver;
            _webElement = webElement;
            _by = by;
        }

        public override By By
        {
            get
            {
                return _by;
            }
        }

        public override string Text
        {
            get
            {
                return _webElement?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                return _webElement?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                return _webElement?.Displayed;
            }
        }

        public override void Click()
        {
            WaitToBeClickable(By);
            _webElement?.Click();
        }

        public override string GetAttribute(string attributeName)
        {
            return _webElement?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            _webElement?.Clear();
            _webElement?.SendKeys(text);
        }

        private void WaitToBeClickable(By by, int timeoutInSeconds = 30)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.IgnoreExceptionTypes(typeof(WebDriverException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(StaleElementReferenceException));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            }
        }
    }
}
