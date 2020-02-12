using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestsReadabilityDemos
{
    public class WebElement : Element
    {
        private readonly IWebDriver _webDriver;
        private readonly IWebElement _webElement;
        private readonly By _by;

        public WebElement(IWebDriver webDriver, IWebElement webElement, By by)
        {
            _webDriver = webDriver;
            _webElement = webElement;
            _by = by;
        }

        public override By By => _by;

        public override string Text => _webElement?.Text;

        public override bool? Enabled => _webElement?.Enabled;

        public override bool? Displayed => _webElement?.Displayed;

        public override void Click()
        {
            WaitToBeClickable(By);
            _webElement?.Click();
        }

        public override Element FindElement(By locator)
        {
            return new WebElement(_webDriver, _webElement?.FindElement(locator), locator);
        }

        public override string GetAttribute(string attributeName)
        {
            return _webElement?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Thread.Sleep(500);
            _webElement?.Clear();
            _webElement?.SendKeys(text);
        }

        private void WaitToBeClickable(By by)
        {
            var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(30));
            webDriverWait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
        }
    }
}
