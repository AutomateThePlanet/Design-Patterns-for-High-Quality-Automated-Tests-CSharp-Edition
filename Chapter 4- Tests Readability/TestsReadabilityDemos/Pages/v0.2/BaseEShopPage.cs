using OpenQA.Selenium;

namespace TestsReadabilityDemos.Second
{
    public abstract class BaseEShopPage
    {
        protected readonly Driver Driver;

        private Element _searchField => Driver.FindElement(By.Id("woocommerce-product-search-field-0"));

        private Element _homeLink => Driver.FindElement(By.LinkText("Home"));
        private Element _blogLink => Driver.FindElement(By.LinkText("Blog"));
        private Element _cartLink => Driver.FindElement(By.LinkText("Cart"));
        private Element _checkoutLink => Driver.FindElement(By.LinkText("Cart"));
        private Element _myAccountLink => Driver.FindElement(By.LinkText("My Account"));
        private Element _promotionsLink => Driver.FindElement(By.LinkText("Promotions"));

        private Element _cartIcon => Driver.FindElement(By.ClassName("cart-contents"));
        private Element _cartAmount => Driver.FindElement(By.ClassName("amount"));

        private Element _breadcrumb => Driver.FindElement(By.ClassName("woocommerce-breadcrumb"));

        public BaseEShopPage(Driver driver)
        {
            Driver = driver;
        }

        protected abstract string Url { get; }

        public void Open()
        {
            Driver.GoToUrl(Url);
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

        public void OpenBreadcrumbItem(string itemToOpen)
        {
            _breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }
    }
}
