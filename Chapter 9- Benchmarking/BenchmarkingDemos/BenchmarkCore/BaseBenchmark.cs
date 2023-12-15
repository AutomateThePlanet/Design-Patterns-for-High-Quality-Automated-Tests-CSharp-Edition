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
using System;
using System.Diagnostics;
using System.Reflection;

namespace BenchmarkingDemos.BenchmarkCore;

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
