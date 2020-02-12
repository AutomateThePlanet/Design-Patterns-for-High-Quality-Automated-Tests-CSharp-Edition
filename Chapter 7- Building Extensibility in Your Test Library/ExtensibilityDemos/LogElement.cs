using System;
using System.Collections.Generic;
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public class LogElement : ElementDecorator
    {
        public LogElement(Element element)
            : base(element)
        {
        }

        public override By By => Element?.By;

        public override string Text
        {
            get
            {
                Console.WriteLine($"Element Text = {Element?.Text}");
                return Element?.Text;
            }
        }

        public override bool? Enabled
        {
            get
            {
                Console.WriteLine($"Element Enabled = {Element?.Enabled}");
                return Element?.Enabled;
            }
        }

        public override bool? Displayed
        {
            get
            {
                Console.WriteLine($"Element Displayed = {Element?.Displayed}");
                return Element?.Displayed;
            }
        }

        public override void Click()
        {
            Console.WriteLine($"Element Clicked");
            Element?.Click();
        }

        public override Element Find(FindStrategy findStrategy)
        {
            return Element?.Find(findStrategy);
        }

        public override List<Element> FindAll(FindStrategy findStrategy)
        {
            return Element?.FindAll(findStrategy);
        }

        public override List<Element> FindAllByClass(string cssClass)
        {
            return Element?.FindAllByClass(cssClass);
        }

        public override List<Element> FindAllByCss(string css)
        {
            return Element?.FindAllByCss(css);
        }

        public override List<Element> FindAllById(string id)
        {
            return Element?.FindAllById(id);
        }

        public override List<Element> FindAllByLinkText(string linkText)
        {
            return Element?.FindAllByLinkText(linkText);
        }

        public override List<Element> FindAllByTag(string tag)
        {
            return Element?.FindAllByTag(tag);
        }

        public override List<Element> FindAllByXPath(string xpath)
        {
            return Element?.FindAllByXPath(xpath);
        }

        public override Element FindByClass(string cssClass)
        {
            return Element?.FindByClass(cssClass);
        }

        public override Element FindByCss(string css)
        {
            return Element?.FindByCss(css);
        }

        public override Element FindById(string id)
        {
            return Element?.FindById(id);
        }

        public override Element FindByLinkText(string linkText)
        {
            return Element?.FindByLinkText(linkText);
        }

        public override Element FindByTag(string tag)
        {
            return Element?.FindByTag(tag);
        }

        public override Element FindByXPath(string xpath)
        {
            return Element?.FindByXPath(xpath);
        }

        ////public override Element FindElement(By locator)
        ////{
        ////    Console.WriteLine($"Find Element with locator = {locator.ToString()}");
        ////    return Element?.FindElement(locator);
        ////}

        public override string GetAttribute(string attributeName)
        {
            Console.WriteLine($"Get Element's Attribute = {attributeName}");
            return Element?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Console.WriteLine($"Type Text = {text}");
            Element?.TypeText(text);
        }

        public override void WaitToExists()
        {
            Console.WriteLine($"Wait for Element with locator = {By}");
            Element?.WaitToExists();
        }
    }
}