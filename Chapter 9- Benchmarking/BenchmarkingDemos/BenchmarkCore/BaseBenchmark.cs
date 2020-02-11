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
            Driver = new LoggingDriver(new WebDriver());
            new BrowserLaunchTestBehaviorObserver(CurrentTestExecutionSubject, Driver);
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

        private MethodInfo GetCurrentExecutionMethodInfo()
        {
            var stackTrace = new StackTrace();
            var benchmarkMethodMemberInfo = stackTrace.GetFrame(2).GetMethod() as MethodInfo;
            return benchmarkMethodMemberInfo;
        }
    }
}
