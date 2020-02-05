using System;
using System.Diagnostics;
using System.Reflection;

namespace BenchmarkingDemos.BenchmarkCore
{
    public class BaseBenchmark
    {
        private static readonly ITestExecutionSubject CurrentTestExecutionSubject;

        static BaseBenchmark()
        {
            CurrentTestExecutionSubject = new TestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(CurrentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            CurrentTestExecutionSubject.MemberInstantiated(memberInfo);
        }

        protected static Driver Driver { get; set; }

        public void BenchmarkInitialize(Action benchmarkInitializeAction = null)
        {
            var benchmarkMethodMemberInfo = GetCurrentExecutionMethodInfo();
            CurrentTestExecutionSubject.PreInitialize(benchmarkMethodMemberInfo);
            benchmarkInitializeAction?.Invoke();
            CurrentTestExecutionSubject.PostInitialize(benchmarkMethodMemberInfo);
        }

        public void BenchmarkCleanup(Action benchmarkCleanupAction = null)
        {
            var benchmarkMethodMemberInfo = GetCurrentExecutionMethodInfo();
            CurrentTestExecutionSubject.PreCleanup(benchmarkMethodMemberInfo);
            benchmarkCleanupAction?.Invoke();
            CurrentTestExecutionSubject.PostCleanup(benchmarkMethodMemberInfo);
        }

        private static void InitializeTestExecutionBehaviorObservers(ITestExecutionSubject currentTestExecutionSubject)
        {
            Driver = new LoggingDriver(new WebDriver());
            new BrowserLaunchTestBehaviorObserver(currentTestExecutionSubject, Driver);
        }

        private MethodInfo GetCurrentExecutionMethodInfo()
        {
            var stackTrace = new StackTrace();
            var benchmarkMethodMemberInfo = stackTrace.GetFrame(2).GetMethod() as MethodInfo;
            return benchmarkMethodMemberInfo;
        }
    }
}
