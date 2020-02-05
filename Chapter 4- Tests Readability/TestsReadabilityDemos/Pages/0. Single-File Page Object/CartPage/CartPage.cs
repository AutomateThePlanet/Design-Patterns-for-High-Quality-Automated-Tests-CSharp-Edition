using System.Threading;
using OpenQA.Selenium;

namespace TestsReadabilityDemos
{
    public class CartPage
    {
        private readonly Driver _driver;

        public CartPage(Driver driver)
        {
            _driver = driver;
        }

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
