using OpenQA.Selenium;

namespace ApiUsabilityDemos.Seventh
{
    public class BreadcrumbSection
    {
        private readonly IElementFindService _driver;
        
        public BreadcrumbSection(IElementFindService driver)
        {
            _driver = driver;
        }
        private Element Breadcrumb => _driver.FindElement(By.ClassName("woocommerce-breadcrumb"));

        public void OpenBreadcrumbItem(string itemToOpen)
        {
            Breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }        
    }
}
