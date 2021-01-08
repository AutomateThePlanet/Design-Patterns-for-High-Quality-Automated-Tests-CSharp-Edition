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
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestsMaintainabilityDemos.Facades.First
{
    public class MainPageAssertions
    {
        private readonly MainPageElements _pageElements;

        public MainPageAssertions(MainPageElements pageElements)
        {
            _pageElements = pageElements;
        }

        public void AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _pageElements.GetProductBoxByName(name).GetAttribute("href");

            Assert.AreEqual(expectedLink, actualLink);
        }
    }
}
