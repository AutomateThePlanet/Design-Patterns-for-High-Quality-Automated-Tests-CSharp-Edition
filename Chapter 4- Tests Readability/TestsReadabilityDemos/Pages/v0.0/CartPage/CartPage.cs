using System.Threading;
using OpenQA.Selenium;

namespace TestsReadabilityDemos
{
    public class CartPage
    {
        private readonly Driver _driver;

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

        public void ApplyCoupon(string coupon)
        {
            _couponCodeTextField.TypeText(coupon);
            _applyCouponButton.Click();
            Thread.Sleep(2000);

        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            _quantityBox.TypeText(newQuantity.ToString());
            _updateCart.Click();
            Thread.Sleep(4000);
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
