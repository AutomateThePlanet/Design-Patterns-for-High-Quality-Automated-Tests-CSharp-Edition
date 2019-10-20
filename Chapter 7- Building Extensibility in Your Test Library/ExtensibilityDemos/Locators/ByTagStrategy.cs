using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByTagStrategy : ByStrategy
    {
        public ByTagStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.TagName(Value);
    }
}
