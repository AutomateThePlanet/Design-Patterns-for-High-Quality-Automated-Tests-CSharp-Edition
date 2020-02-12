using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StabilizeTestsDemos.SixthVersion
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject CurrentTestExecutionSubject;
        private static readonly Driver LoggingDriver;
        private static TestContext _testContextInstance;

        static BaseTest()
        {
            CurrentTestExecutionSubject = new MsTestExecutionSubject();
            LoggingDriver = new LoggingDriver(new WebDriver());
            new BrowserLaunchTestBehaviorObserver(CurrentTestExecutionSubject, LoggingDriver);
            var memberInfo = MethodBase.GetCurrentMethod();
            CurrentTestExecutionSubject.TestInstantiated(memberInfo);
        }

        public BaseTest()
        {
            Driver = LoggingDriver;
        }

        public Driver Driver { get; set; }

        public TestContext TestContext
        {
            get => _testContextInstance;
            set => _testContextInstance = value;
        }

        public string TestName => TestContext.TestName;

        [ClassInitialize]
        public static void OnClassInitialize(TestContext context)
        {
        }

        [ClassCleanup]
        public static void OnClassCleanup()
        {
        }

        [TestInitialize]
        public void CoreTestInit()
        {
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            CurrentTestExecutionSubject.PreTestInit(TestContext, memberInfo);
            TestInit();
            CurrentTestExecutionSubject.PostTestInit(TestContext, memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            CurrentTestExecutionSubject.PreTestCleanup(TestContext, memberInfo);
            TestCleanup();
            CurrentTestExecutionSubject.PostTestCleanup(TestContext, memberInfo);

        }

        ////[AssemblyCleanup]
        ////public static void AssemblyCleanup()
        ////{
        ////    LoggingDriver?.Quit();
        ////}

        public virtual void TestInit()
        {
        }

        public virtual void TestCleanup()
        {
        }
    }
}
