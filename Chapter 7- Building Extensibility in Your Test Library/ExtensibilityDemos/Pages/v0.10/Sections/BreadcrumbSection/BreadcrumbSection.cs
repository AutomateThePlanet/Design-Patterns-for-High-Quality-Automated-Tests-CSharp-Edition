namespace ExtensibilityDemos.Tenth
{
    public class BreadcrumbSection
    {
        private readonly Driver _driver;
        private Element _breadcrumb => _driver.FindByClass("woocommerce-breadcrumb");
        
        public BreadcrumbSection(Driver driver)
        {
            _driver = driver;
        }
     
        public void OpenBreadcrumbItem(string itemToOpen)
        {
            _breadcrumb.FindByLinkText(itemToOpen).Click();
        }        
    }
}
