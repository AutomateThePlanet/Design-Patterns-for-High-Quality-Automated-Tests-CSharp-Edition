using OpenQA.Selenium;

namespace ApiUsabilityDemos.Seventh
{
    public class BreadcrumbSection
    {
        private readonly IElementFindService _driver;
        private Element _breadcrumb => _driver.FindElement(By.ClassName("woocommerce-breadcrumb"));
        
        public BreadcrumbSection(IElementFindService driver)
        {
            _driver = driver;
        }
     
        public void OpenBreadcrumbItem(string itemToOpen)
        {
            _breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }        
    }
}
