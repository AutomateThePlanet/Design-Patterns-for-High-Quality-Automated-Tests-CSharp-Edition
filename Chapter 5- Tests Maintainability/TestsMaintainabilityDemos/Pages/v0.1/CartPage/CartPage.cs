using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.First
{
    public class CartPage
    {
        private readonly Driver _driver;

        private Element _searchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));

        private Element _homeLink => _driver.FindElement(By.LinkText("Home"));
        private Element _blogLink => _driver.FindElement(By.LinkText("Blog"));
        private Element _cartLink => _driver.FindElement(By.LinkText("Cart"));
        private Element _checkoutLink => _driver.FindElement(By.LinkText("Cart"));
        private Element _myAccountLink => _driver.FindElement(By.LinkText("My Account"));
        private Element _promotionsLink => _driver.FindElement(By.LinkText("Promotions"));

        private Element _cartIcon => _driver.FindElement(By.ClassName("cart-contents"));
        private Element _cartAmount => _driver.FindElement(By.ClassName("amount"));

        private Element _breadcrumb => _driver.FindElement(By.ClassName("woocommerce-breadcrumb"));

        private Element _couponCodeTextField => _driver.FindElement(By.Id("coupon_code"));
        private Element _applyCouponButton => _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        private Element _quantityBox => _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        private Element _updateCart => _driver.FindElement(By.CssSelector("[value*='Update cart']"));
        private Element _messageAlert => _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        private Element _totalSpan => _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        private Element _proceedToCheckout => _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public CartPage(Driver driver)
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

        public void OpenBreadcrumbItem(string itemToOpen)
        {
            _breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }

        public void ApplyCoupon(string coupon)
        {
            _couponCodeTextField.TypeText(coupon);
            _applyCouponButton.Click();
            _driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            _quantityBox.TypeText(newQuantity.ToString());
            _updateCart.Click();
            _driver.WaitForAjax();
        }

        public void ProceedToCheckout()
        {
            _proceedToCheckout.Click();
        }

        public string GetTotal()
        {
            return _totalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return _messageAlert.Text;
        }
    }
}
