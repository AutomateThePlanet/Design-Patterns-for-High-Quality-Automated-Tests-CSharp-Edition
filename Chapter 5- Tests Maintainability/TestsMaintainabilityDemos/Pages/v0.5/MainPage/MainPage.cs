using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Fifth
{
    public class MainPage : NavigatableEShopPage
    {
        private Element _addToCartFalcon9 => Driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element _viewCartButton => Driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public MainPage(Driver driver) : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart()
        {
            Open();
            _addToCartFalcon9.Click();
            _viewCartButton.Click();
        }

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }

        protected override void WaitForElementToBeDisplayed()
        {
            _addToCartFalcon9.WaitToExists();
        }

        private Element GetProductBoxByName(string name)
        {
            return Driver.FindElement(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
        }
    }
}