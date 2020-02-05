using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByLinkTextStrategy : FindStrategy
    {
        public ByLinkTextStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.LinkText(Value);
    }
}
