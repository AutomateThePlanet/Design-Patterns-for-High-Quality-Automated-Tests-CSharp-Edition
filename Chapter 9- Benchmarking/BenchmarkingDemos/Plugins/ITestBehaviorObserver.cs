using System.Reflection;

namespace BenchmarkingDemos
{
    public interface ITestBehaviorObserver
    {
        void PreInitialize(MemberInfo memberInfo);

        void PostInitialize(MemberInfo memberInfo);

        void PreCleanup(MemberInfo memberInfo);

        void PostCleanup(MemberInfo memberInfo);

        void MemberInstantiated(MemberInfo memberInfo);
    }
}
