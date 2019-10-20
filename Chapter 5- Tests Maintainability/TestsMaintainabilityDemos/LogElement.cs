using System;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos
{
    public class LogElement : ElementDecorator
    {
        public LogElement(Element element)
            : base(element)
        {
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
                Console.WriteLine($"Element Text = {element?.Text}");
                return element?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                Console.WriteLine($"Element Enabled = {element?.Enabled}");
                return element?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                Console.WriteLine($"Element Displayed = {element?.Displayed}");
                return element?.Displayed;
            }
        }

        public override void Click()
        {
            Console.WriteLine($"Element Clicked");
            element?.Click();
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine($"Find element with locator = {locator.ToString()}");
            return element?.FindElement(locator);
        }

        public override string GetAttribute(string attributeName)
        {
            Console.WriteLine($"Get Element's Attribute = {attributeName}");
            return element?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Console.WriteLine($"Type Text = {text}");
            element?.TypeText(text);
        }

        public override void WaitToExists(int timeoutInSeconds = 30)
        {
            Console.WriteLine($"Wait for element with locator = {By}");
            element?.WaitToExists(timeoutInSeconds);
        }
    }
}
