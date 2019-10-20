using System.Collections.Generic;
using OpenQA.Selenium;

namespace ApiUsabilityDemos
{
    public interface IElementFindService
    {
        Element FindElement(By locator);
        List<Element> FindElements(By locator);
    }
}
