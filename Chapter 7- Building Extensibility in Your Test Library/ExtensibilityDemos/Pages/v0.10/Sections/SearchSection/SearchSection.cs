using OpenQA.Selenium;

namespace ExtensibilityDemos.Tenth
{
    public class SearchSection
    {
        private readonly Driver _driver;
        private Element _searchField => _driver.FindById("woocommerce-product-search-field-0");
        
        public SearchSection(Driver driver)
        {
            _driver = driver;
        }

        public void SearchForItem(string searchText)
        {
            _searchField.TypeText(searchText);
        }
    }
}
