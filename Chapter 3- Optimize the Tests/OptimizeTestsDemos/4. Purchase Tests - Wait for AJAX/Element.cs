using OpenQA.Selenium;

namespace StabilizeTestsDemos.FourthVersion
{
    public abstract class Element 
    {
        public abstract By By { get; }
        public abstract string Text { get; }
        public abstract bool? Enabled { get; }
        public abstract bool? Displayed { get; }
        public abstract void TypeText(string text);
        public abstract void Click();
        public abstract string GetAttribute(string attributeName);
    }
}
