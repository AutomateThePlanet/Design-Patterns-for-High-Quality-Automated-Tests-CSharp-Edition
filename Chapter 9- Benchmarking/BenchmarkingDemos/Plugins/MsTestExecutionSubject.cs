using System.Collections.Generic;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BenchmarkingDemos
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

        public void PreInitialize(MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PreInitialize(memberInfo);
            }
        }
        public void PostInitialize(MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PostInitialize(memberInfo);
            }
        }

        public void PreCleanup(MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PreCleanup(memberInfo);
            }
        }

        public void PostCleanup(MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.PostCleanup(memberInfo);
            }
        }

        public void MemberInstantiated(MemberInfo memberInfo)
        {
            foreach (var currentObserver in _testBehaviorObservers)
            {
                currentObserver.MemberInstantiated(memberInfo);
            }
        }
    }
}
