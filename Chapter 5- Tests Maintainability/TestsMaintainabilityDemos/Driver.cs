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
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos
{
    public abstract class Driver
    {
        public abstract void Start(Browser browser);
        public abstract void Quit();
        public abstract void GoToUrl(string url);
        public abstract Element FindElement(By locator);
        public abstract List<Element> FindElements(By locator);
        public abstract void WaitForAjax();
        public abstract void WaitUntilPageLoadsCompletely();
    }
}
