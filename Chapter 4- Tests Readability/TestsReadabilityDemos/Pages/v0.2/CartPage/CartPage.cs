using System.Threading;
using OpenQA.Selenium;

namespace TestsReadabilityDemos.Second
{
    public class CartPage : BaseEShopPage
    {
        private Element _couponCodeTextField => Driver.FindElement(By.Id("coupon_code"));
        private Element _applyCouponButton => Driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        private Element _quantityBox => Driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        private Element _updateCart => Driver.FindElement(By.CssSelector("[value*='Update cart']"));
        private Element _messageAlert => Driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        private Element _totalSpan => Driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        private Element _proceedToCheckout => Driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public CartPage(Driver driver) : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

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
