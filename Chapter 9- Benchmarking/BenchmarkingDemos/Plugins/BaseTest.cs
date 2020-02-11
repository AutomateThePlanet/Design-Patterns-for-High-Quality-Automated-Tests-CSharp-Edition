using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BenchmarkingDemos
{
    [TestClass]
    public class BaseTest
    {
        private static readonly ITestExecutionSubject CurrentTestExecutionSubject;
        private static readonly Driver LoggingDriver;

        static BaseTest()
        {
            CurrentTestExecutionSubject = new TestExecutionSubject();
            LoggingDriver = new LoggingDriver(new WebDriver());
            new BrowserLaunchTestBehaviorObserver(CurrentTestExecutionSubject, LoggingDriver);
            var memberInfo = MethodBase.GetCurrentMethod();
            CurrentTestExecutionSubject.MemberInstantiated(memberInfo);
        }

        public BaseTest()
        {
            Driver = LoggingDriver;
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
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            CurrentTestExecutionSubject.PreInitialize(memberInfo);
            TestInit();
            CurrentTestExecutionSubject.PostInitialize(memberInfo);
        }

        [TestCleanup]
        public void CoreTestCleanup()
        {
            var memberInfo = GetType().GetMethod(TestContext.TestName);
            CurrentTestExecutionSubject.PreCleanup(memberInfo);
            TestCleanup();
            CurrentTestExecutionSubject.PostCleanup(memberInfo);

        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            LoggingDriver?.Quit();
        }

        public virtual void TestInit()
        {
        }

        public virtual void TestCleanup()
        {
        }
    }
}
