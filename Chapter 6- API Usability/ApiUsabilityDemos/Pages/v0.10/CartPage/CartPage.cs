using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Tenth
{
    public class CartPage : NavigatableEShopPage
    {
        private CartPageElements _cartPageElements;

        private CartPage(Driver driver) : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            _cartPageElements = new CartPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; set; }


        public CartPage ApplyCoupon(string coupon)
        {
            _cartPageElements.CouponCodeTextField.TypeText(coupon);
            _cartPageElements.ApplyCouponButton.Click();
            Driver.WaitForAjax();

            return this;
        }

        public CartPage IncreaseProductQuantity(int newQuantity)
        {
            _cartPageElements.QuantityBox.TypeText(newQuantity.ToString());
            _cartPageElements.UpdateCart.Click();
            Driver.WaitForAjax();

            return this;
        }

        public CartPage ProceedToCheckout()
        {
            _cartPageElements.ProceedToCheckout.Click();

            return this;
        }

        public CartPage AssertTotal(string expectedTotal)
        {
            Assert.AreEqual(_cartPageElements.TotalSpan.Text, expectedTotal);

            return this;
        }

        public CartPage AssertMessageNotification(string expectedMessage)
        {
            Assert.AreEqual(_cartPageElements.MessageAlert.Text, expectedMessage);

            return this;
        }

        protected override void WaitForElementToDisplay()
        {
            _cartPageElements.CouponCodeTextField.WaitToExists();
        }
    }
}
