using System.Reflection;

namespace BenchmarkingDemos
{
    public interface ITestExecutionSubject
    {
        void Attach(ITestBehaviorObserver observer);

        void Detach(ITestBehaviorObserver observer);

        void PreInitialize(MemberInfo memberInfo);

        void PostInitialize(MemberInfo memberInfo);

        void PreCleanup(MemberInfo memberInfo);

        void PostCleanup(MemberInfo memberInfo);

        void MemberInstantiated(MemberInfo memberInfo);
    }
}
