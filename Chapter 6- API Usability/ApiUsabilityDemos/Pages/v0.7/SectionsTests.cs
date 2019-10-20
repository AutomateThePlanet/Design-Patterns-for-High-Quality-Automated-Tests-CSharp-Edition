using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Seventh
{
    [TestClass]
    public class SectionsTests
    {
        private static IBrowserService _browserService;
        private static MainPage _mainPage;
        private static CartPage _cartPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var driver = new LoggingDriver(new WebDriver());
            _browserService = driver;
            _browserService.Start(Browser.Chrome);
            _mainPage = new MainPage(driver, driver);
            _cartPage = new CartPage(driver, driver, driver);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _browserService.Quit();
        }

        [TestMethod]
        public void Falcon9LinkAddsCorrectProduct()
        {
            _mainPage.Open();

            _mainPage.MainPageAssertions.AssertProductBoxLink("Falcon 9", "http://demos.bellatrix.solutions/product/falcon-9/");
        }

        [TestMethod]
        public void SaturnVLinkAddsCorrectProduct()
        {
            _mainPage.Open();

            _mainPage.MainPageAssertions.AssertProductBoxLink("Saturn V", "http://demos.bellatrix.solutions/product/saturn-v/");
        }
    }
}