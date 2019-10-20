using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByIdContainingStrategy : ByStrategy
    {
        public ByIdContainingStrategy(string value)
            : base(value)
        {
        }

        public override By Convert()
        {
            return By.CssSelector($"[id*='{Value}']");
        }
    }
}
