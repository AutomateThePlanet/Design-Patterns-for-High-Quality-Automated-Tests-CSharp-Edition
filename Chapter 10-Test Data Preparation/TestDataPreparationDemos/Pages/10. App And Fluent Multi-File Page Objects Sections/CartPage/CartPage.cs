using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestDataPreparationDemos.Configuration;

namespace TestDataPreparationDemos.Tenth
{
    public class CartPage : NavigatableEShopPage
    {
        private readonly CartPageElements _elements;

        private CartPage(Driver driver) 
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            _elements = new CartPageElements(driver);
        }

        public BreadcrumbSection BreadcrumbSection { get; }

        ////protected override string Url => "http://demos.bellatrix.solutions/cart/";
        protected override string Url => UrlDeterminer.GetShopUrl("cart");

        public CartPage ApplyCoupon(string coupon)
        {
            _elements.CouponCodeTextField.TypeText(coupon);
            _elements.ApplyCouponButton.Click();
            Driver.WaitForAjax();

            return this;
        }

        public CartPage IncreaseProductQuantity(int newQuantity)
        {
            _elements.QuantityBox.TypeText(newQuantity.ToString());
            _elements.UpdateCart.Click();
            Driver.WaitForAjax();
            return this;
        }

        public CartPage ProceedToCheckout()
        {
            _elements.ProceedToCheckout.Click();
            return this;
        }

        public CartPage AssertTotal(string expectedTotal)
        {
            Assert.AreEqual(_elements.TotalSpan.Text, expectedTotal);
            return this;
        }

        public CartPage AssertMessageNotification(string expectedMessage)
        {
            Assert.AreEqual(_elements.MessageAlert.Text, expectedMessage);
            return this;
        }

        protected override void WaitForElementToDisplay()
        {
            _elements.CouponCodeTextField.WaitToExists();
        }
    }
}
