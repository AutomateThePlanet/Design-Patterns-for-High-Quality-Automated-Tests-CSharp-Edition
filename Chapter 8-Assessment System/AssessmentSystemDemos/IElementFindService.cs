using System.Collections.Generic;
using OpenQA.Selenium;

namespace AssessmentSystemDemos
{
    public interface IElementFindService
    {
        Element FindElement(By locator);
        List<Element> FindElements(By locator);
    }
}
