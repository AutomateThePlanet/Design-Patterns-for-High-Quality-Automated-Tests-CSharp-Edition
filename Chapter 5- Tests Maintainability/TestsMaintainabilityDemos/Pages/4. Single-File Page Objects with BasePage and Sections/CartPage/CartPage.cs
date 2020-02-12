using System.Threading;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Fourth
{
    public class CartPage : BaseEShopPage
    {
        public CartPage(Driver driver)
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
        }

        public BreadcrumbSection BreadcrumbSection { get; }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        private Element CouponCodeTextField => Driver.FindElement(By.Id("coupon_code"));
        private Element ApplyCouponButton => Driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        private Element QuantityBox => Driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        private Element UpdateCart => Driver.FindElement(By.CssSelector("[value*='Update cart']"));
        private Element MessageAlert => Driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        private Element TotalSpan => Driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        private Element ProceedToCheckout => Driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public void ApplyCoupon(string coupon)
        {
            CouponCodeTextField.TypeText(coupon);
            ApplyCouponButton.Click();
            Driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.TypeText(newQuantity.ToString());
            UpdateCart.Click();
            Driver.WaitForAjax();
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            Driver.WaitUntilPageLoadsCompletely();
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
