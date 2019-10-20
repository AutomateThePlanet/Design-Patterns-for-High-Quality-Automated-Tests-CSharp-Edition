using OpenQA.Selenium;

namespace StabilizeTestsDemos.FourthVersion
{
    public abstract class ElementDecorator : Element
    {
        protected Element element;

        public ElementDecorator(Element element)
        {
            this.element = element;
        }

        public override By By
        {
            get
            {
                return element?.By;
            }
        }

        public override string Text
        {
            get
            {
                return element?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                return element?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                return element?.Displayed;
            }
        }

        public override void Click()
        {
            element?.Click();
        }

        public override string GetAttribute(string attributeName)
        {
            return element?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            element?.TypeText(text);
        }
    }
}
