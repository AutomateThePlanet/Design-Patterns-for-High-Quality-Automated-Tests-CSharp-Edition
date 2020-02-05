using OpenQA.Selenium;

namespace ApiUsabilityDemos.Eight
{
    public class SearchSection
    {
        private readonly IElementFindService _driver;
        
        public SearchSection(IElementFindService driver)
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
