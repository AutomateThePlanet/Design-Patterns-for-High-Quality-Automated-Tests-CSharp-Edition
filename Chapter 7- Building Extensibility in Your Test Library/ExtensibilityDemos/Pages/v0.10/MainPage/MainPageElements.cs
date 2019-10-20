using OpenQA.Selenium;

namespace ExtensibilityDemos.Tenth
{
    public class MainPageElements
    {
        private readonly Driver _driver;

        public MainPageElements(Driver driver) => _driver = driver;

        public Element AddToCartFalcon9 => _driver.FindByCss("[data-product_id*='28']");
        public Element ViewCartButton => _driver.FindByCss("[class*='added_to_cart wc-forward']");

        public Element GetProductBoxByName(string name)
        {
            return _driver.FindByXPath($"//h2[text()='{name}']/parent::a[1]");
        }
    }
}
