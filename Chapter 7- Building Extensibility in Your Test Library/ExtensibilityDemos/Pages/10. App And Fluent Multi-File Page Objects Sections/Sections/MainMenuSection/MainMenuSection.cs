namespace ExtensibilityDemos.Tenth
{
    public class MainMenuSection
    {
        private readonly Driver _driver;

        public MainMenuSection(Driver driver)
        {
            _driver = driver;
        }

        private Element HomeLink => _driver.FindByLinkText("Home");
        private Element BlogLink => _driver.FindByLinkText("Blog");
        private Element CartLink => _driver.FindByLinkText("Cart");
        private Element CheckoutLink => _driver.FindByLinkText("Checkout");
        private Element MyAccountLink => _driver.FindByLinkText("My Account");
        private Element PromotionsLink => _driver.FindByLinkText("Promotions");
        
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
