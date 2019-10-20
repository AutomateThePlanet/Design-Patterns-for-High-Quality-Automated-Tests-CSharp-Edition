using OpenQA.Selenium;

namespace ApiUsabilityDemos.Seventh
{
    public class CartInfoSection
    {
        private readonly IElementFindService _driver;

        private Element _cartIcon => _driver.FindElement(By.ClassName("cart-contents"));
        private Element _cartAmount => _driver.FindElement(By.ClassName("amount"));
        
        public CartInfoSection(IElementFindService driver)
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
