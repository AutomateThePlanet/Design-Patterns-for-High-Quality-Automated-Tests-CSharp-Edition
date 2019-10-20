using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentSystemDemos.Facades.First
{
    public class CheckoutPageAssertions
    {
        private readonly CheckoutPageElements _elements;

        public CheckoutPageAssertions(CheckoutPageElements elements) => _elements = elements;

        public void AssertOrderReceived()
        {
            Assert.AreEqual(_elements.ReceivedMessage.Text, "Order received");
        }
    }
}
