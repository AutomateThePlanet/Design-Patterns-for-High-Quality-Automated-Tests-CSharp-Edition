using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ExtensibilityDemos
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

        public override TElement Find<TByStrategy, TElement>(string value) => element?.Find<TByStrategy, TElement>(value);
        public override List<TElement> FindAll<TByStrategy, TElement>(string value) => element?.FindAll<TByStrategy, TElement>(value);
        public override List<Element> FindAllByClass(string cssClass) => element?.FindAllByClass(cssClass);
        public override List<Element> FindAllByCss(string css) => element?.FindAllByCss(css);
        public override List<Element> FindAllById(string id) => element?.FindAllById(id);
        public override List<Element> FindAllByLinkText(string linkText) => element?.FindAllByLinkText(linkText);
        public override List<Element> FindAllByTag(string tag) => element?.FindAllByTag(tag);
        public override List<Element> FindAllByXPath(string xpath) => element?.FindAllByXPath(xpath);
        public override Element FindByClass(string cssClass) => element?.FindByClass(cssClass);
        public override Element FindByCss(string css) => element?.FindByCss(css);
        public override Element FindById(string id) => element?.FindById(id);
        public override Element FindByLinkText(string linkText) => element?.FindByLinkText(linkText);
        public override Element FindByTag(string tag) => element?.FindByTag(tag);
        public override Element FindByXPath(string xpath) => element?.FindByXPath(xpath);

        ////public override Element FindElement(By locator)
        ////{
        ////    Console.WriteLine($"Find element with locator = {locator.ToString()}");
        ////    return element?.FindElement(locator);
        ////}

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