using OpenQA.Selenium;

namespace TestsReadabilityDemos
{
    public class MainPage
    {
        private readonly Driver _driver;
        private readonly string _url = "http://demos.bellatrix.solutions/";

        public MainPage(Driver driver)
        {
            _driver = driver;
        }

        private Element AddToCartFalcon9 => _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element ViewCartButton => _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public void AddRocketToShoppingCart()
        {
            _driver.GoToUrl(_url);
            AddToCartFalcon9.Click();
            ViewCartButton.Click();
        }
    }
}
