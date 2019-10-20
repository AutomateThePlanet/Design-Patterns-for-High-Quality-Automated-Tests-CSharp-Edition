using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Facades.First
{
    public class CartPageAssertions
    {
        private readonly CartPageElements _elements;

        public CartPageAssertions(CartPageElements elements) => _elements = elements;

        public void AssertCouponAppliedSuccessfully()
        {
            Assert.AreEqual("Coupon code applied successfully.", _elements.MessageAlert.Text);
        }

        public void AssertTotalPrice(string expectedPrice)
        {
            Assert.AreEqual(expectedPrice, _elements.TotalSpan.Text);
        }
    }
}
