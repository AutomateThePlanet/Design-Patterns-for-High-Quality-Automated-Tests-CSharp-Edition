using BenchmarkDotNet.Attributes;
using System;
using System.Diagnostics;
using System.Reflection;

namespace BenchmarkingDemos.BenchmarkCore
{
    public class BaseBenchmark
    {
        private static readonly ITestExecutionSubject _currentTestExecutionSubject;

        static BaseBenchmark()
        {
            _currentTestExecutionSubject = new TestExecutionSubject();
            InitializeTestExecutionBehaviorObservers(_currentTestExecutionSubject);
            var memberInfo = MethodBase.GetCurrentMethod();
            _currentTestExecutionSubject.MemberInstantiated(memberInfo);
        }

        protected static Driver Driver { get; set; }

        public void BenchmarkInitialize(Action benchmarkInitializeAction = null)
        {
            var benchmarkMethodMemberInfo = GetCurrentExecutionMethodInfo();
            _currentTestExecutionSubject.PreInitialize(benchmarkMethodMemberInfo);
            benchmarkInitializeAction?.Invoke();
            _currentTestExecutionSubject.PostInitialize(benchmarkMethodMemberInfo);
        }

        public void BenchmarkCleanup(Action benchmarkCleanupAction = null)
        {
            var benchmarkMethodMemberInfo = GetCurrentExecutionMethodInfo();
            _currentTestExecutionSubject.PreCleanup(benchmarkMethodMemberInfo);
            benchmarkCleanupAction?.Invoke();
            _currentTestExecutionSubject.PostCleanup(benchmarkMethodMemberInfo);
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
