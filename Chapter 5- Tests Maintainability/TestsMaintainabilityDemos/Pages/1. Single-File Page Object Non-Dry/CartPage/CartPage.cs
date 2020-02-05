using System.Threading;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.First
{
    public class CartPage
    {
        private readonly Driver _driver;

        public CartPage(Driver driver)
        {
            _driver = driver;
        }

        private Element SearchField => _driver.FindElement(By.Id("woocommerce-product-search-field-0"));
        private Element HomeLink => _driver.FindElement(By.LinkText("Home"));
        private Element BlogLink => _driver.FindElement(By.LinkText("Blog"));
        private Element CartLink => _driver.FindElement(By.LinkText("Cart"));
        private Element CheckoutLink => _driver.FindElement(By.LinkText("Cart"));
        private Element MyAccountLink => _driver.FindElement(By.LinkText("My Account"));
        private Element PromotionsLink => _driver.FindElement(By.LinkText("Promotions"));
        private Element CartIcon => _driver.FindElement(By.ClassName("cart-contents"));
        private Element CartAmount => _driver.FindElement(By.ClassName("amount"));
        private Element Breadcrumb => _driver.FindElement(By.ClassName("woocommerce-breadcrumb"));
        private Element CouponCodeTextField => _driver.FindElement(By.Id("coupon_code"));
        private Element ApplyCouponButton => _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        private Element QuantityBox => _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        private Element UpdateCart => _driver.FindElement(By.CssSelector("[value*='Update cart']"));
        private Element MessageAlert => _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        private Element TotalSpan => _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        private Element ProceedToCheckout => _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public void SearchForItem(string searchText)
        {
            SearchField.TypeText(searchText);
        }

        public void OpenHomePage()
        {
            HomeLink.Click();
        }

        public void OpenBlogPage()
        {
            BlogLink.Click();
        }

        public void OpenMyAccountPage()
        {
            MyAccountLink.Click();
        }

        public void OpenPromotionsPage()
        {
            PromotionsLink.Click();
        }

        public string GetCurrentAmount()
        {
            return CartAmount.Text;
        }

        public void OpenCart()
        {
            CartIcon.Click();
        }

        public void OpenBreadcrumbItem(string itemToOpen)
        {
            Breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }

        public void ApplyCoupon(string coupon)
        {
            CouponCodeTextField.TypeText(coupon);
            ApplyCouponButton.Click();
            Thread.Sleep(2000);

        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.TypeText(newQuantity.ToString());
            UpdateCart.Click();
            Thread.Sleep(4000);
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
        }

        public string GetTotal()
        {
            return TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return MessageAlert.Text;
        }
    }
}