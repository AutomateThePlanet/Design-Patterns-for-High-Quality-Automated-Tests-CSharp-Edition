using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos.Pages
{
    public static class WebElementFindExtensions
    {
        public static TElement CreateByIdContaining<TElement>(this TElement element, string idContaining)
            where TElement : Element => element.Find<ByIdContainingStrategy, TElement>(idContaining);
    }
}
