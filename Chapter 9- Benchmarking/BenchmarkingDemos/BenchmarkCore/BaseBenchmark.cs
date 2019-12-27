using System;
using System.Diagnostics;
using System.Reflection;

namespace BenchmarkingDemos.BenchmarkCore
{
    public abstract class BaseBenchmark
    {
        private static readonly ITestExecutionSubject _currentTestExecutionSubject;
        private static Driver _driver;

        static BaseBenchmark()
        {
            _currentTestExecutionSubject = new MsTestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(_currentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            _currentTestExecutionSubject.MemberInstantiated(memberInfo);
        }

        public void BenchmarkInitialize(Action benchmarkInitializeAction = null)
        {
            var benchmarkMethodMemberInfo = GetCurrentExecutionMethodInfo();
            _currentTestExecutionSubject.PreInitialize(benchmarkMethodMemberInfo);
            benchmarkInitializeAction?.Invoke();
            _currentTestExecutionSubject.PostInitialize(benchmarkMethodMemberInfo);
        }

        public void BenchmarkCleanup(string testName, Action benchmarkCleanupAction = null)
        {
            var benchmarkMethodMemberInfo = GetCurrentExecutionMethodInfo();
            _currentTestExecutionSubject.PreCleanup(benchmarkMethodMemberInfo);
            benchmarkCleanupAction?.Invoke();
            _currentTestExecutionSubject.PostCleanup(benchmarkMethodMemberInfo);
        }

        private static void InitializeTestExecutionBehaviorObservers(ITestExecutionSubject currentTestExecutionSubject)
        {
            _driver = new LoggingDriver(new WebDriver());
            new BrowserLaunchTestBehaviorObserver(currentTestExecutionSubject, _driver);
        }

        private MethodInfo GetCurrentExecutionMethodInfo()
        {
            var stackTrace = new StackTrace();
            var benchmarkMethodMemberInfo = stackTrace.GetFrame(2).GetMethod() as MethodInfo;
            return benchmarkMethodMemberInfo;
        }
    }
}
