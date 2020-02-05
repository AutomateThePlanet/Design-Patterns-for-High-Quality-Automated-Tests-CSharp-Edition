using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StabilizeTestsDemos.SixthVersion
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject CurrentTestExecutionSubject;
        private static TestContext _testContextInstance;
        private static Driver _driver;

        static BaseTest()
        {
            CurrentTestExecutionSubject = new MsTestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(CurrentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            CurrentTestExecutionSubject.TestInstantiated(memberInfo);
        }

        public BaseTest()
        {
            Driver = _driver;
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
            var memberInfo = GetCurrentExecutionMethodInfo();
            CurrentTestExecutionSubject.PreTestInit(TestContext, memberInfo);
            TestInit();
            CurrentTestExecutionSubject.PostTestInit(TestContext, memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetCurrentExecutionMethodInfo();
            CurrentTestExecutionSubject.PreTestCleanup(TestContext, memberInfo);
            TestCleanup();
            CurrentTestExecutionSubject.PostTestCleanup(TestContext, memberInfo);

        }

        ////[AssemblyCleanup]
        ////public static void AssemblyCleanup()
        ////{
        ////    _driver?.Quit();
        ////}

        public virtual void TestInit()
        {
        }

        public virtual void TestCleanup()
        {
        }

        private MethodInfo GetCurrentExecutionMethodInfo()
        {
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            return memberInfo;
        }

        private static void InitializeTestExecutionBehaviorObservers(ITestExecutionSubject currentTestExecutionSubject)
        {
            _driver = new LoggingDriver(new WebDriver());
            new BrowserLaunchTestBehaviorObserver(currentTestExecutionSubject, _driver);
        }
    }
}
