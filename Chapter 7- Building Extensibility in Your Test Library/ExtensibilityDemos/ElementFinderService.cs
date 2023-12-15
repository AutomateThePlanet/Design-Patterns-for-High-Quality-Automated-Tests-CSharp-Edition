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
using ExtensibilityDemos.Locators;
using OpenQA.Selenium;

namespace ExtensibilityDemos;

public class ElementFinderService
{
    private readonly ISearchContext _searchContext;
    private readonly IWebDriver _driver;

    public ElementFinderService(ISearchContext searchContext, IWebDriver driver)
    {
        _searchContext = searchContext;
        _driver = driver;
    }

    public IWebElement Find(FindStrategy findStrategy)
    {
        Wait.To.Exists().WaitUntil(_searchContext, _driver, findStrategy.Convert());
        var element = _searchContext.FindElement(findStrategy.Convert());
        return element;
    }

    public IEnumerable<IWebElement> FindAll(FindStrategy findStrategy)
    {
        Wait.To.Exists().WaitUntil(_searchContext, _driver, findStrategy.Convert());
        IEnumerable<IWebElement> result = _searchContext.FindElements(findStrategy.Convert());
        return result;
    }
}
