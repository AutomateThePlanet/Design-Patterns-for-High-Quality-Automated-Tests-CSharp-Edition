using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Facades.Second
{
    public class SearchSection
    {
        private readonly Driver _driver;
        
        public SearchSection(Driver driver)
        {
            _driver = driver;
        }
        private Element SearchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));

        public void SearchForItem(string searchText)
        {
            SearchField.TypeText(searchText);
        }
    }
}
