using ExtensibilityDemos.Extensions;

namespace ExtensibilityDemos
{
    public class CartPageElements
    {
        private readonly Driver _driver;

        public CartPageElements(Driver driver) => _driver = driver;

        public Element CouponCodeTextField => _driver.CreateByIdContaining("coupon_code");
        public Element ApplyCouponButton => _driver.FindByCss("[value*='Apply coupon']");
        public Element QuantityBox => _driver.FindByCss("[class*='input-text qty text']");
        public Element UpdateCart => _driver.FindByCss("[value*='Update cart']");
        public Element MessageAlert => _driver.FindByCss("[class*='woocommerce-message']");
        public Element TotalSpan => _driver.FindByXPath("//*[@class='order-total']//span");
        public Element ProceedToCheckout => _driver.FindByCss("[class*='checkout-button button alt wc-forward']");
    }
}
