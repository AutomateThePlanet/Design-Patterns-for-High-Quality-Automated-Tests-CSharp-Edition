using OpenQA.Selenium;

namespace ApiUsabilityDemos.Eight
{
    public class MainMenuSection
    {
        private readonly IElementFindService _driver;

        public MainMenuSection(IElementFindService driver)
        {
            _driver = driver;
        }

        private Element HomeLink => _driver.FindElement(By.LinkText("Home"));
        private Element BlogLink => _driver.FindElement(By.LinkText("Blog"));
        private Element CartLink => _driver.FindElement(By.LinkText("Cart"));
        private Element CheckoutLink => _driver.FindElement(By.LinkText("Checkout"));
        private Element MyAccountLink => _driver.FindElement(By.LinkText("My Account"));
        private Element PromotionsLink => _driver.FindElement(By.LinkText("Promotions"));
        
        public void OpenHomePage()
        {
            HomeLink.Click();
        }

        public void OpenBlogPage()
        {
            BlogLink.Click();
        }

        public void OpenMyAccountPage()
        {
            MyAccountLink.Click();
        }

        public void OpenPromotionsPage()
        {
            PromotionsLink.Click();
        }
    }
}
