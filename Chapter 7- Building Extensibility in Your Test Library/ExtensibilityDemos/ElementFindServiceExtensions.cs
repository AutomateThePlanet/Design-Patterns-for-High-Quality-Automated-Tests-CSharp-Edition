using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos.Extensions
{
    public static class ElementFindServiceExtensions
    {
        public static Element CreateByIdContaining(this IElementFindService findService, string idContaining)
        {
            return findService.Find<ByIdContainingStrategy, Element>(idContaining);
        }
    }
}
