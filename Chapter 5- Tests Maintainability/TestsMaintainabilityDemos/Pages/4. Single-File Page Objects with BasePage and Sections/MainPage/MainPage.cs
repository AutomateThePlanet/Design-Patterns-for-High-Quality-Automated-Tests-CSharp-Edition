using OpenQA.Selenium;

namespace TestsMaintainabilityDemos.Fourth
{
    public class MainPage : BaseEShopPage
    {
        public MainPage(Driver driver) 
            : base(driver)
        {
        }

        private Element АddToCartFalcon9 => Driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element ViewCartButton => Driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        protected override string Url => "http://demos.bellatrix.solutions/";

        public void AddRocketToShoppingCart()
        {
            Open();
            АddToCartFalcon9.Click();
            ViewCartButton.Click();
        }
    }
}
