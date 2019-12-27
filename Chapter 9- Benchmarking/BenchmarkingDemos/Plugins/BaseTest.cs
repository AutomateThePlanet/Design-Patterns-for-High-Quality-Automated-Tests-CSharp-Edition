using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BenchmarkingDemos
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject _currentTestExecutionSubject;
        private static Driver _driver;

        static BaseTest()
        {
            _currentTestExecutionSubject = new MsTestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(_currentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            _currentTestExecutionSubject.MemberInstantiated(memberInfo);
        }

        public BaseTest()
        {
            Driver = _driver;
        }

        public Driver Driver { get; set; }

        public static TestContext TestContext { get; set; }

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
            _currentTestExecutionSubject.PreInitialize(memberInfo);
            TestInit();
            _currentTestExecutionSubject.PostInitialize(memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetCurrentExecutionMethodInfo();
            _currentTestExecutionSubject.PreCleanup(memberInfo);
            TestCleanup();
            _currentTestExecutionSubject.PostCleanup(memberInfo);

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            _driver?.Quit();
        }

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
