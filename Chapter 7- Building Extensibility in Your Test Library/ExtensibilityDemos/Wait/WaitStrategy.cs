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
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ExtensibilityDemos;

public abstract class WaitStrategy
{
    protected WaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
    {
        TimeoutInterval = TimeSpan.FromSeconds(timeoutIntervalInSeconds ?? 30);
        SleepInterval = TimeSpan.FromSeconds(sleepIntervalInSeconds ?? 2);
    }

    protected TimeSpan TimeoutInterval { get; }

    protected TimeSpan SleepInterval { get; }

    public abstract void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by);

    protected void WaitUntil(Func<ISearchContext, bool> waitCondition, IWebDriver driver)
    {
        var webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeoutInterval, SleepInterval);
        webDriverWait.Until(waitCondition);
    }

    protected void WaitUntil(Func<ISearchContext, IWebElement> waitCondition, IWebDriver driver)
    {
        var webDriverWait = new WebDriverWait(new SystemClock(), driver, TimeoutInterval, SleepInterval);
        webDriverWait.Until(waitCondition);
    }

    protected IWebElement FindElement(ISearchContext searchContext, By by)
    {
        var element = searchContext.FindElement(by);
        return element;
    }
}
