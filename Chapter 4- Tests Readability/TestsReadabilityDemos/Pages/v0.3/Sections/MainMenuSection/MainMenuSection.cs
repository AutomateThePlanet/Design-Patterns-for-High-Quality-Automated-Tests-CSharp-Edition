using OpenQA.Selenium;

namespace TestsReadabilityDemos.Third
{
    public class MainMenuSection
    {
        private readonly Driver _driver;

        private Element _homeLink => _driver.FindElement(By.LinkText("Home"));
        private Element _blogLink => _driver.FindElement(By.LinkText("Blog"));
        private Element _cartLink => _driver.FindElement(By.LinkText("Cart"));
        private Element _checkoutLink => _driver.FindElement(By.LinkText("Checkout"));
        private Element _myAccountLink => _driver.FindElement(By.LinkText("My Account"));
        private Element _promotionsLink => _driver.FindElement(By.LinkText("Promotions"));

        public MainMenuSection(Driver driver)
        {
            _driver = driver;
        }
        
        public void OpenHomePage()
        {
            _homeLink.Click();
        }

        public void OpenBlogPage()
        {
            _blogLink.Click();
        }

        public void OpenMyAccountPage()
        {
            _myAccountLink.Click();
        }

        public void OpenPromotionsPage()
        {
            _promotionsLink.Click();
        }
    }
}
