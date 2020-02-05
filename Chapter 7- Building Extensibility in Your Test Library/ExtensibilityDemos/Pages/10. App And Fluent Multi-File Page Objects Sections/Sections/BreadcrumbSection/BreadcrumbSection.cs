using OpenQA.Selenium;

namespace ExtensibilityDemos.Tenth
{
    public class BreadcrumbSection
    {
        private readonly Driver _driver;
        
        public BreadcrumbSection(Driver driver)
        {
            _driver = driver;
        }
        private Element Breadcrumb => _driver.FindByClass("woocommerce-breadcrumb");

        public void OpenBreadcrumbItem(string itemToOpen)
        {
            Breadcrumb.FindByLinkText(itemToOpen).Click();
        }        
    }
}
