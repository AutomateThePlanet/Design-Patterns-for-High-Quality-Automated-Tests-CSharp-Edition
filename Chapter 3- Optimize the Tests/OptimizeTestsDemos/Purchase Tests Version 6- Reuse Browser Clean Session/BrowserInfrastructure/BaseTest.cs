using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StabilizeTestsDemos.SixthVersion
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject _currentTestExecutionSubject;
        private static TestContext _testContextInstance;
        private static Driver _driver;

        static BaseTest()
        {
            _currentTestExecutionSubject = new MsTestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(_currentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            _currentTestExecutionSubject.TestInstantiated(memberInfo);
        }

        public BaseTest()
        {
            Driver = _driver;
        }

        public Driver Driver { get; set; }

        public TestContext TestContext
        {
            get
            {
                return _testContextInstance;
            }
            set
            {
                _testContextInstance = value;
            }
        }

        public string TestName
        {
            get
            {
                return TestContext.TestName;
            }
        }

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
            _currentTestExecutionSubject.PreTestInit(TestContext, memberInfo);
            TestInit();
            _currentTestExecutionSubject.PostTestInit(TestContext, memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetCurrentExecutionMethodInfo();
            _currentTestExecutionSubject.PreTestCleanup(TestContext, memberInfo);
            TestCleanup();
            _currentTestExecutionSubject.PostTestCleanup(TestContext, memberInfo);

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
