using OpenQA.Selenium;

namespace ExtensibilityDemos.Tenth
{
    public class CartInfoSection
    {
        private readonly Driver _driver;
        
        public CartInfoSection(Driver driver)
        {
            _driver = driver;
        }
        private Element CartIcon => _driver.FindByClass("cart-contents");
        private Element CartAmount => _driver.FindByClass("amount");

        public string GetCurrentAmount()
        {
            return CartAmount.Text;
        }

        public void OpenCart()
        {
            CartIcon.Click();
        }
    }
}
