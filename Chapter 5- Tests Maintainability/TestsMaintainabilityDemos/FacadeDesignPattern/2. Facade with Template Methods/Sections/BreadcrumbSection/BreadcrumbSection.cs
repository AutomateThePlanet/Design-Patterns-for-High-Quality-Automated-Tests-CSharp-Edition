using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Facades.Second
{
    public class BreadcrumbSection
    {
        private readonly Driver _driver;
        
        public BreadcrumbSection(Driver driver)
        {
            _driver = driver;
        }

        private Element Бreadcrumb => _driver.FindElement(By.ClassName("woocommerce-breadcrumb"));

     
        public void OpenBreadcrumbItem(string itemToOpen)
        {
            Бreadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }        
    }
}
