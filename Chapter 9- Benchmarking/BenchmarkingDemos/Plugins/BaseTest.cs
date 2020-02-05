using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BenchmarkingDemos
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject CurrentTestExecutionSubject;
        private static Driver _driver;

        static BaseTest()
        {
            CurrentTestExecutionSubject = new TestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(CurrentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            CurrentTestExecutionSubject.MemberInstantiated(memberInfo);
        }

        public BaseTest()
        {
            Driver = _driver;
        }

        public Driver Driver { get; }

        public static TestContext TestContext { get; set; }

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
            CurrentTestExecutionSubject.PreInitialize(memberInfo);
            TestInit();
            CurrentTestExecutionSubject.PostInitialize(memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetCurrentExecutionMethodInfo();
            CurrentTestExecutionSubject.PreCleanup(memberInfo);
            TestCleanup();
            CurrentTestExecutionSubject.PostCleanup(memberInfo);

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
