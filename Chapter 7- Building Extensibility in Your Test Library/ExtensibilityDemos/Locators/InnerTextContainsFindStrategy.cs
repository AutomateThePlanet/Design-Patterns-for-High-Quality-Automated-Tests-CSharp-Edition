using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class InnerTextContainsFindStrategy : FindStrategy
    {
        public InnerTextContainsFindStrategy(string value)
            : base(value)
        {
        }

        public override By Convert()
        {
            return By.XPath($"//*[contains(text(), '{Value}')]");
        }
    }
}
