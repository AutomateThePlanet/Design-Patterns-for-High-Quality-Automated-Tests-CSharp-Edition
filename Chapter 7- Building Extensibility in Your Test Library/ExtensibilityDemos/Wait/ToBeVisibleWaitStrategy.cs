// Copyright 2021 Automate The Planet Ltd.
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

namespace ExtensibilityDemos
{
    public class ToBeVisibleWaitStrategy : WaitStrategy
    {
        public ToBeVisibleWaitStrategy(int? timeoutIntervalInSeconds = null, int? sleepIntervalInSeconds = null)
            : base(timeoutIntervalInSeconds, sleepIntervalInSeconds)
        {
        }

        public override void WaitUntil(ISearchContext searchContext, IWebDriver driver, By by)
        {
            WaitUntil(ElementIsVisible(searchContext, by), driver);
        }

        private Func<ISearchContext, bool> ElementIsVisible(ISearchContext searchContext, By by)
        {
            return _ =>
            {
                try
                {
                    var element = FindElement(searchContext, by);
                    return element != null && element.Displayed;
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
}
