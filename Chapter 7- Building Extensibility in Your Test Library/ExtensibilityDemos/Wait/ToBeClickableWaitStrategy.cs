﻿// Copyright 2024 Automate The Planet Ltd.
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

namespace ExtensibilityDemos;

public class ToBeClickableWaitStrategy : WaitStrategy
{
    public ToBeClickableWaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
        : base(timeoutIntervalInSeconds, sleepIntervalInSeconds)
    {
    }

    public override void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by)
    {
        WaitUntil(ElementIsClickable(searchContext, by), driver);
    }

    private Func<ISearchContext, bool> ElementIsClickable(ISearchContext searchContext, By by)
    {
        return _ =>
        {
            var element = FindElement(searchContext, by);
            try
            {
                return element != null && element.Enabled;
            }
            catch (StaleElementReferenceException)
            {
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        };
    }
}
