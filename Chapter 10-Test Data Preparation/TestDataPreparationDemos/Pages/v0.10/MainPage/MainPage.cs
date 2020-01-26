using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataPreparationDemos.Tenth
{
    public class MainPage : NavigatableEShopPage
    {
        private MainPageElements _elements;

        private MainPage(Driver driver) 
            : base(driver)
        {
            _elements = new MainPageElements(driver);
        }

        protected override string Url => ConfigurationService.Instance.GetWebSettings().BaseUrl;

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

        protected override void WaitForPageLoad()
        {
            _elements.AddToCartFalcon9.WaitToExists();
        }
    }
}