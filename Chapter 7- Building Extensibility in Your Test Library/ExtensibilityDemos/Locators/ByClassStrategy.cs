using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByClassStrategy : FindStrategy
    {
        public ByClassStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.XPath($"//*[@class='{Value}']");
    }
}
