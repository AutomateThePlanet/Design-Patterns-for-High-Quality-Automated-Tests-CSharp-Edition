// Copyright 2024 Automate The Planet Ltd.
// Author: Anton Angelov
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using System.Collections.Generic;
using System.Reflection;

namespace BenchmarkingDemos;

public class TestExecutionSubject : ITestExecutionSubject
{
    private readonly List<ITestBehaviorObserver> _testBehaviorObservers;

    public TestExecutionSubject()
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
