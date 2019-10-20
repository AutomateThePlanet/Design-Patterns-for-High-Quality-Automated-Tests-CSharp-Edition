using OpenQA.Selenium;

namespace TestsReadabilityDemos.Fourth
{
    public class CartInfoSection
    {
        private readonly Driver _driver;

        private Element _cartIcon => _driver.FindElement(By.ClassName("cart-contents"));
        private Element _cartAmount => _driver.FindElement(By.ClassName("amount"));
        
        public CartInfoSection(Driver driver)
        {
            _driver = driver;
        }
        
        public string GetCurrentAmount()
        {
            return _cartAmount.Text;
        }

        public void OpenCart()
        {
            _cartIcon.Click();
        }
    }
}
