using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class LinkTextFindStrategy : FindStrategy
    {
        public LinkTextFindStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.LinkText(Value);
    }
}
