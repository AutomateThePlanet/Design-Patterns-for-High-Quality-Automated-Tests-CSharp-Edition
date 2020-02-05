using OpenQA.Selenium;

namespace AssessmentSystemDemos
{
    public abstract class ElementDecorator : Element
    {
        protected Element Element;

        protected ElementDecorator(Element element)
        {
            this.Element = element;
        }

        public override By By
        {
            get
            {
                return Element?.By;
            }
        }

        public override string Text
        {
            get
            {
                return Element?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                return Element?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                return Element?.Displayed;
            }
        }

        public override void Click()
        {
            Element?.Click();
        }

        public override string GetAttribute(string attributeName)
        {
            return Element?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Element?.TypeText(text);
        }
    }
}
