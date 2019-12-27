using System.Reflection;

namespace BenchmarkingDemos
{
    public class BaseTestBehaviorObserver : ITestBehaviorObserver
    {
        private readonly ITestExecutionSubject _testExecutionSubject;

        public BaseTestBehaviorObserver(ITestExecutionSubject testExecutionSubject)
        {
            _testExecutionSubject = testExecutionSubject;
            testExecutionSubject.Attach(this);
        }

        public virtual void PreInitialize(MemberInfo memberInfo)
        {
        }

        public virtual void PostInitialize(MemberInfo memberInfo)
        {
        }

        public virtual void PreCleanup(MemberInfo memberInfo)
        {
        }

        public virtual void PostCleanup(MemberInfo memberInfo)
        {
        }

        public virtual void MemberInstantiated(MemberInfo memberInfo)
        {
        }
    }
}
