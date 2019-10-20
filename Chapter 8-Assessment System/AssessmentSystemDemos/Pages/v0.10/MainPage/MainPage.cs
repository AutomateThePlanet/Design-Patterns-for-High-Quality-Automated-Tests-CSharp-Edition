using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentSystemDemos.Tenth
{
    public class MainPage : NavigatableEShopPage
    {
        private MainPageElements _mainPageElements;

        private MainPage(Driver driver) : base(driver)
        {
            _mainPageElements = new MainPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public MainPage AddRocketToShoppingCart()
        {
            Open();
            _mainPageElements.AddToCartFalcon9.Click();
            _mainPageElements.ViewCartButton.Click();

            return this;
        }

        public MainPage AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _mainPageElements.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);

            return this;
        }

        protected override void WaitForElementToDisplay()
        {
            _mainPageElements.AddToCartFalcon9.WaitToExists();
        }
    }
}