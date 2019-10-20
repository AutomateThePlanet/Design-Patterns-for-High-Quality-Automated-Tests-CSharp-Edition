using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.First
{
    public class MainPage
    {
        private readonly Driver _driver;
        private readonly string _url = "http://demos.bellatrix.solutions/";

        private Element _searchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));

        private Element _homeLink => _driver.FindElement(By.LinkText("Home"));
        private Element _blogLink => _driver.FindElement(By.LinkText("Blog"));
        private Element _cartLink => _driver.FindElement(By.LinkText("Cart"));
        private Element _checkoutLink => _driver.FindElement(By.LinkText("Cart"));
        private Element _myAccountLink => _driver.FindElement(By.LinkText("My Account"));
        private Element _promotionsLink => _driver.FindElement(By.LinkText("Promotions"));

        private Element _cartIcon => _driver.FindElement(By.ClassName("cart-contents"));
        private Element _cartAmount => _driver.FindElement(By.ClassName("amount"));

        private Element _addToCartFalcon9 => _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element _viewCartButton => _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public MainPage(Driver driver)
        {
            _driver = driver;
        }

        public void SearchForItem(string searchText)
        {
            _searchField.TypeText(searchText);
        }

        public void OpenHomePage()
        {
            _homeLink.Click();
        }

        public void OpenBlogPage()
        {
            _blogLink.Click();
        }

        public void OpenMyAccountPage()
        {
            _myAccountLink.Click();
        }

        public void OpenPromotionsPage()
        {
            _promotionsLink.Click();
        }

        public string GetCurrentAmount()
        {
            return _cartAmount.Text;
        }

        public void OpenCart()
        {
            _cartIcon.Click();
        }

        public void AddRocketToShoppingCart()
        {
            _driver.GoToUrl(_url);
            _addToCartFalcon9.Click();
            _viewCartButton.Click();
        }
    }
}
