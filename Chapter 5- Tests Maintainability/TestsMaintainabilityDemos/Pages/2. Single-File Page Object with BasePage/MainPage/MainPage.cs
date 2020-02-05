using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Second
{
    public class MainPage : BaseEShopPage
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
    }
}
