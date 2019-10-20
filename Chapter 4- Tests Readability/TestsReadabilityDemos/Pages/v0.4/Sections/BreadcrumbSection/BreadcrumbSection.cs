using OpenQA.Selenium;

namespace TestsReadabilityDemos.Fourth
{
    public class BreadcrumbSection
    {
        private readonly Driver _driver;
        private Element _breadcrumb => _driver.FindElement(By.ClassName("woocommerce-breadcrumb"));
        
        public BreadcrumbSection(Driver driver)
        {
            _driver = driver;
        }
     
        public void OpenBreadcrumbItem(string itemToOpen)
        {
            _breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }        
    }
}
