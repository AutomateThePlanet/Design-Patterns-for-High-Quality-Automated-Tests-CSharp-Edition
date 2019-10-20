using OpenQA.Selenium;

namespace TestsReadabilityDemos
{
    public class MainPage
    {
        private readonly Driver _driver;
        private readonly string _url = "http://demos.bellatrix.solutions/";

        private Element _addToCartFalcon9 => _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element _viewCartButton => _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public MainPage(Driver driver)
        {
            _driver = driver;
        }

        public void AddRocketToShoppingCart()
        {
            _driver.GoToUrl(_url);
            _addToCartFalcon9.Click();
            _viewCartButton.Click();
        }
    }
}
