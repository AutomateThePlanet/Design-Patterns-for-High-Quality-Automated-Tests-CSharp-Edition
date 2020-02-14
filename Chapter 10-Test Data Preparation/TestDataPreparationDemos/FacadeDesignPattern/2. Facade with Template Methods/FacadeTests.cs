using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataPreparationDemos.Facades.Second
{
    [TestClass]
    public class FacadeTests
    {
        private static Driver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;
        private static CheckoutPage _checkoutPage;
        private static PurchaseFirstVersionFacade _purchaseFirstVersionFacade;

        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(Browser.Chrome);
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
            _checkoutPage = new CheckoutPage(_driver);
            _purchaseFirstVersionFacade = new PurchaseFirstVersionFacade(_mainPage, _cartPage, _checkoutPage);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestMethod]
        public void PurchaseSaturnVWithRandomNoteFacade()
        {
            var purchaseInfo = new PurchaseInfo();
            var fixture = new Fixture();
            purchaseInfo.Note = fixture.Create<string>();

            _purchaseFirstVersionFacade.PurchaseItem("Saturn V", "happybirthday", 3, "355.00€", purchaseInfo);
        }

        // .NET Core does not support the DataSource attribute. If you try to access test data in this way in a .NET Core or UWP unit test project, 
        // you'll see an error similar to "'TestContext' does not contain a definition for 'DataRow' and no accessible extension method 'DataRow'
        // accepting a first argument of type 'TestContext' could be found (are you missing a using directive or an assembly reference?)".
        ////[TestMethod]
        ////[DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", "TestsData.csv", "TestsData#csv", DataAccessMethod.Sequential)]
        ////public void PurchaseWithFacadeDataDrivenCsv()
        ////{
        ////    var purchaseInfo = new PurchaseInfo();

        ////    string rocketName = TestContext.DataRow["rocketName"];
        ////    string couponName = TestContext.DataRow["couponName"];          
        ////    int quantity = int.Parse(this.TestContext.DataRow["quantity"]);
        ////    string expectedPrice = TestContext.DataRow["expectedPrice"];

        ////    _purchaseFirstVersionFacade.PurchaseItem(
        ////        rocketName,
        ////        couponName,
        ////        quantity,
        ////        expectedPrice,
        ////        purchaseInfo);
        ////}
    }
}