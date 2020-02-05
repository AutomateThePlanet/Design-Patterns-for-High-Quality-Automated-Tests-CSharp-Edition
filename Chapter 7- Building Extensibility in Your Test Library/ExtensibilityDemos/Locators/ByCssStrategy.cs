using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByCssStrategy : FindStrategy
    {
        public ByCssStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.CssSelector(Value);
    }
}
