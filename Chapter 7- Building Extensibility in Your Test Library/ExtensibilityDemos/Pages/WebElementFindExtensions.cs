using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos.Pages
{
    public static class WebElementFindExtensions
    {
        public static TElement CreateByIdContaining<TElement>(this TElement element, string idContaining)
            where TElement : Element
        {
            return element.Find<IdContainingFindStrategy, TElement>(new IdContainingFindStrategy(idContaining));
        }
    }
}