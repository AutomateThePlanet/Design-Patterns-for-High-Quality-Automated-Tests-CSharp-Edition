using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByInnerTextContainsStrategy : ByStrategy
    {
        public ByInnerTextContainsStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.XPath($"//*[contains(text(), '{Value}')]");
    }
}
