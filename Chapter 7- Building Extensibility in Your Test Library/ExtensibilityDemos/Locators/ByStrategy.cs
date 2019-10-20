namespace ExtensibilityDemos.Locators
{
    public abstract class ByStrategy
    {
        public ByStrategy(string value) => Value = value;

        public string Value { get; }

        public abstract OpenQA.Selenium.By Convert();
    }
}
