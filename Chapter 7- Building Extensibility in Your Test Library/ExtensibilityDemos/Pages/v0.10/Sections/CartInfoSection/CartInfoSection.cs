namespace ExtensibilityDemos.Tenth
{
    public class CartInfoSection
    {
        private readonly Driver _driver;

        private Element _cartIcon => _driver.FindByClass("cart-contents");
        private Element _cartAmount => _driver.FindByClass("amount");
        
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
