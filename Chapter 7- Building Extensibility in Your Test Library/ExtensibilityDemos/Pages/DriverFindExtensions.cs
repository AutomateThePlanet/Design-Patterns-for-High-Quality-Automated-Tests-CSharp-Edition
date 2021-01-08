using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos.Pages
{
    public static class DriverFindExtensions
    {
        public static Element FindByIdContaining(this Driver driver, string idContaining)
        {
            return driver.Find(new IdContainingFindStrategy(idContaining));
        }
    }
}