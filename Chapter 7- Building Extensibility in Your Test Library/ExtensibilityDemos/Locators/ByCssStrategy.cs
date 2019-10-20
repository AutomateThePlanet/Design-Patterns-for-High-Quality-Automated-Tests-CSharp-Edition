using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByCssStrategy : ByStrategy
    {
        public ByCssStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.CssSelector(Value);
    }
}
