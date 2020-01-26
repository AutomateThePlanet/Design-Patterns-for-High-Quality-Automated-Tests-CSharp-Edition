using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentSystemDemos.Tenth
{
    public class CartPage : NavigatableEShopPage
    {
        private CartPageElements _еlements;

        private CartPage(Driver driver) 
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            _еlements = new CartPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        public BreadcrumbSection BreadcrumbSection { get; set; }


        public CartPage ApplyCoupon(string coupon)
        {
            _еlements.CouponCodeTextField.TypeText(coupon);
            _еlements.ApplyCouponButton.Click();
            Driver.WaitForAjax();

            return this;
        }

        public CartPage IncreaseProductQuantity(int newQuantity)
        {
            _еlements.QuantityBox.TypeText(newQuantity.ToString());
            _еlements.UpdateCart.Click();
            Driver.WaitForAjax();

            return this;
        }

        public CartPage ProceedToCheckout()
        {
            _еlements.ProceedToCheckout.Click();

            return this;
        }

        public CartPage AssertTotal(string expectedTotal)
        {
            Assert.AreEqual(_еlements.TotalSpan.Text, expectedTotal);

            return this;
        }

        public CartPage AssertMessageNotification(string expectedMessage)
        {
            Assert.AreEqual(_еlements.MessageAlert.Text, expectedMessage);

            return this;
        }

        protected override void WaitForPageLoad()
        {
            _еlements.CouponCodeTextField.WaitToExists();
        }
    }
}
