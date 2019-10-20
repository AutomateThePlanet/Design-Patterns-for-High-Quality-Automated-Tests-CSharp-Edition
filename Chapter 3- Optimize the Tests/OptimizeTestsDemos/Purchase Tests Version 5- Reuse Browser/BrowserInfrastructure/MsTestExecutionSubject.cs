using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StabilizeTestsDemos.FifthVersion
{
    public class MsTestExecutionSubject : ITestExecutionSubject
    {
        private readonly List<ITestBehaviorObserver> _testBehaviorObservers;

        public MsTestExecutionSubject()
        {
            _testBehaviorObservers = new List<ITestBehaviorObserver>();
        }

        public void Attach(ITestBehaviorObserver observer)
        {
            _testBehaviorObservers.Add(observer);
        }

        public void Detach(ITestBehaviorObserver observer)
        {
            _testBehaviorObservers.Remove(observer);
        }

        public void PreTestInit(TestContext context, MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PreTestInit(context, memberInfo);
            }
        }
        public void PostTestInit(TestContext context, MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PostTestInit(context, memberInfo);
            }
        }

        public void PreTestCleanup(TestContext context, MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PreTestCleanup(context, memberInfo);
            }
        }

        public void PostTestCleanup(TestContext context, MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PostTestCleanup(context, memberInfo);
            }
        }

        public void TestInstantiated(MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.TestInstantiated(memberInfo);
            }
        }
    }
}
