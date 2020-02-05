using OpenQA.Selenium;

namespace ExtensibilityDemos.Locators
{
    public class ByXPathStrategy : FindStrategy
    {
        public ByXPathStrategy(string value)
            : base(value)
        {
        }

        public override By Convert() => By.XPath(Value);

        public override string ToString() => $"XPath = {Value}";
    }
}
