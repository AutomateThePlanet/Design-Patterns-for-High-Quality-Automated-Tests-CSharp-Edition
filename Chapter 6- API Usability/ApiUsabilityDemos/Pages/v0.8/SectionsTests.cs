using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiUsabilityDemos.Eight
{
    [TestClass]
    public class SectionsTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            LoggingSingletonDriver.Instance.Start(Browser.Chrome);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            LoggingSingletonDriver.Instance.Quit();
        }

        [TestMethod]
        public void Falcon9LinkAddsCorrectProduct()
        {
            MainPage.Instance.Open();

            MainPage.Instance.MainPageAssertions.AssertProductBoxLink("Falcon 9", "http://demos.bellatrix.solutions/product/falcon-9/");
        }

        [TestMethod]
        public void SaturnVLinkAddsCorrectProduct()
        {
            MainPage.Instance.Open();

            MainPage.Instance.MainPageAssertions.AssertProductBoxLink("Saturn V", "http://demos.bellatrix.solutions/product/saturn-v/");
        }
    }
}