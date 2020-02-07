using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class IdContainingFindStrategy : FindStrategy
    {
        public IdContainingFindStrategy(string value)
            : base(value)
        {
        }

        public override By Convert()
        {
            return By.CssSelector($"[id*='{Value}']");
        }
    }
}
