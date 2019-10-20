using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsReadabilityDemos.Fourth
{
    [TestClass]
    public class SectionsTests
    {
        private static Driver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(Browser.Chrome);
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void OpenBlogPage()
        {
            _mainPage.MainMenuSection.OpenBlogPage();

            // verify page title
        }

        [TestMethod]
        public void SearchForItem()
        {
            _mainPage.SearchSection.SearchForItem("Falcon 9");

            // add the item to cart
        }

        [TestMethod]
        public void OpenCart()
        {
            _mainPage.CartInfoSection.OpenCart();

            // verify items in the cart
        }
    }
}