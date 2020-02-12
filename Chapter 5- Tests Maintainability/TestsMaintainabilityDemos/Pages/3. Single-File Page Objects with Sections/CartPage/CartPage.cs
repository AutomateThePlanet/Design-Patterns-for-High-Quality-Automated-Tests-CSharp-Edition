using System.Threading;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Third
{
    public class CartPage
    {
        private readonly Driver _driver;

        public CartPage(Driver driver)
        {
            _driver = driver;
            SearchSection = new SearchSection(_driver);
            MainMenuSection = new MainMenuSection(_driver);
            CartInfoSection = new CartInfoSection(_driver);
            BreadcrumbSection = new BreadcrumbSection(_driver);
        }

        public SearchSection SearchSection { get;  }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }
        public BreadcrumbSection BreadcrumbSection { get; }

        private Element CouponCodeTextField => _driver.FindElement(By.Id("coupon_code"));
        private Element ApplyCouponButton => _driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        private Element QuantityBox => _driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        private Element UpdateCart => _driver.FindElement(By.CssSelector("[value*='Update cart']"));
        private Element MessageAlert => _driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        private Element TotalSpan => _driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        private Element ProceedToCheckout => _driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public void ApplyCoupon(string coupon)
        {
            CouponCodeTextField.TypeText(coupon);
            ApplyCouponButton.Click();
            _driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.TypeText(newQuantity.ToString());
            UpdateCart.Click();
            _driver.WaitForAjax();
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            _driver.WaitUntilPageLoadsCompletely();
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