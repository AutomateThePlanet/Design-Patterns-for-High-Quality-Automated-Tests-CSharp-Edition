namespace ExtensibilityDemos.Tenth
{
    public class SearchSection
    {
        private readonly Driver _driver;
        
        public SearchSection(Driver driver)
        {
            _driver = driver;
        }
        private Element SearchField => _driver.FindById("woocommerce-product-search-field-0");

        public void SearchForItem(string searchText)
        {
            SearchField.TypeText(searchText);
        }
    }
}