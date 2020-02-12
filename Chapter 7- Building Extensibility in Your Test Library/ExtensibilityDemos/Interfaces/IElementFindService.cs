using System.Collections.Generic;
using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos
{
    public interface IElementFindService
    {
        ////Element FindElement(By locator);
        ////List<Element> FindElements(By locator);
        Element FindById(string id);
        Element FindByXPath(string xpath);
        Element FindByTag(string tag);
        Element FindByClass(string cssClass);
        Element FindByCss(string css);
        Element FindByLinkText(string linkText);
        List<Element> FindAllById(string id);
        List<Element> FindAllByXPath(string xpath);
        List<Element> FindAllByTag(string tag);
        List<Element> FindAllByClass(string cssClass);
        List<Element> FindAllByCss(string css);
        List<Element> FindAllByLinkText(string linkText);

        List<Element> FindAll(FindStrategy findStrategy);
        Element Find(FindStrategy findStrategy);
    }
}
