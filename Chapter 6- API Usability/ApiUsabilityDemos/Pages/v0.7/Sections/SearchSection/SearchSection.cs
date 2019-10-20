using OpenQA.Selenium;

namespace ApiUsabilityDemos.Seventh
{
    public class SearchSection
    {
        private readonly IElementFindService _driver;
        private Element _searchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));
        
        public SearchSection(IElementFindService driver)
        {
            _driver = driver;
        }

        public void SearchForItem(string searchText)
        {
            _searchField.TypeText(searchText);
        }
    }
}
