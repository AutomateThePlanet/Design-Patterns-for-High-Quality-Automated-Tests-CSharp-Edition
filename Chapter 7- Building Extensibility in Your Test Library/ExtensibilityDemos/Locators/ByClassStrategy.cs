using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByClassStrategy : ByStrategy
    {
        public ByClassStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.XPath($"//*[@class='{Value}']");
    }
}
