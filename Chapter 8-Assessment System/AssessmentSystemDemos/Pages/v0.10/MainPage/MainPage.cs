using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssessmentSystemDemos.Tenth
{
    public class MainPage : NavigatableEShopPage
    {
        private MainPageElements _еlements;

        private MainPage(Driver driver) 
            : base(driver)
        {
            _еlements = new MainPageElements(driver);
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public MainPage AddRocketToShoppingCart()
        {
            Open();
            _еlements.AddToCartFalcon9.Click();
            _еlements.ViewCartButton.Click();

            return this;
        }

        public MainPage AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _еlements.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);

            return this;
        }

        protected override void WaitForPageLoad()
        {
            _еlements.AddToCartFalcon9.WaitToExists();
        }
    }
}