using OpenQA.Selenium;

namespace ExtensibilityDemos.Tenth
{
    public class MainMenuSection
    {
        private readonly Driver _driver;

        private Element _homeLink => _driver.FindByLinkText("Home");
        private Element _blogLink => _driver.FindByLinkText("Blog");
        private Element _cartLink => _driver.FindByLinkText("Cart");
        private Element _checkoutLink => _driver.FindByLinkText("Checkout");
        private Element _myAccountLink => _driver.FindByLinkText("My Account");
        private Element _promotionsLink => _driver.FindByLinkText("Promotions");

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
