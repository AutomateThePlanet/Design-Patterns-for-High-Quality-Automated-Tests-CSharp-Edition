using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExtensibilityDemos.Tenth
{
    public class CartPage : NavigatableEShopPage
    {
        private readonly CartPageElements _cartPageElements;
        private readonly IElementWaitService _elementWaitService;

        private CartPage(Driver driver) : base(driver)
        {
            _elementWaitService = driver;
            BreadcrumbSection = new BreadcrumbSection(Driver);
            _cartPageElements = new CartPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; set; }


        public CartPage ApplyCoupon(string coupon)
        {
            _elementWaitService.Wait(_cartPageElements.CouponCodeTextField, Wait.To.Exists());

            _cartPageElements.CouponCodeTextField.TypeText(coupon);

            _elementWaitService.Wait(_cartPageElements.ApplyCouponButton, Wait.To.BeClickable());
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
