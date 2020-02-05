using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Fifth
{
    public class MainPage : NavigatableEShopPage
    {
        public MainPage(Driver driver) 
            : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/";

        private Element AddToCartFalcon9 => Driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element ViewCartButton => Driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public void AddRocketToShoppingCart()
        {
            Open();
            AddToCartFalcon9.Click();
            ViewCartButton.Click();
        }

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = GetProductBoxByName(name).GetAttribute("href");
            Assert.AreEqual(expectedLink, actualLink);
        }

        protected override void WaitForElementToBeDisplayed()
        {
            AddToCartFalcon9.WaitToExists();
        }

        private Element GetProductBoxByName(string name)
        {
            return Driver.FindElement(By.XPath($"//h2[text()='{name}']/parent::a[1]"));
        }
    }
}