using OpenQA.Selenium;

namespace TestDataPreparationDemos.Tenth
{
    public class SearchSection
    {
        private readonly Driver _driver;
        private Element SearchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));
        
        public SearchSection(Driver driver)
        {
            _driver = driver;
        }

        public void SearchForItem(string searchText)
        {
            SearchField.TypeText(searchText);
        }
    }
}
