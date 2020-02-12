using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos.Pages
{
    public static class WebElementFindExtensions
    {
        public static Element CreateByIdContaining(this Element element, string idContaining)
        {
            return element.Find(new IdContainingFindStrategy(idContaining));
        }
    }
}