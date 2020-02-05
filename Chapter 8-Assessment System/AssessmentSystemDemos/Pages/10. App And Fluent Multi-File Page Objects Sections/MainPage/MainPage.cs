using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentSystemDemos.Tenth
{
    public class MainPage : NavigatableEShopPage
    {
        private readonly MainPageElements _elements;

        private MainPage(Driver driver) 
            : base(driver)
        {
            _elements = new MainPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public MainPage AddRocketToShoppingCart()
        {
            Open();
            _elements.AddToCartFalcon9.Click();
            _elements.ViewCartButton.Click();
            return this;
        }

        public MainPage AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _elements.GetProductBoxByName(name).GetAttribute("href");
            Assert.AreEqual(expectedLink, actualLink);
            return this;
        }

        protected override void WaitForElementToDisplay()
        {
            _elements.AddToCartFalcon9.WaitToExists();
        }
    }
}