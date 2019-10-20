using ApiUsabilityDemos.Pages.Ninth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Ninth
{
    [TestClass]
    public class SectionsTests
    {
        private static App _app;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _app = new App();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _app.Dispose();
        }

        [TestMethod]
        public void Falcon9LinkAddsCorrectProduct()
        {
            var mainPage = _app.GoTo<MainPage>();

            mainPage.MainPageAssertions.AssertProductBoxLink("Falcon 9", "http://demos.bellatrix.solutions/product/falcon-9/");
        }

        [TestMethod]
        public void SaturnVLinkAddsCorrectProduct()
        {
            var mainPage = _app.GoTo<MainPage>();

            mainPage.MainPageAssertions.AssertProductBoxLink("Saturn V", "http://demos.bellatrix.solutions/product/saturn-v/");
        }
    }
}