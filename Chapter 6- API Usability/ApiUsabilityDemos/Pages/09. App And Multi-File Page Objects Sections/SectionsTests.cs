using ApiUsabilityDemos.Pages.Ninth;
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

namespace ApiUsabilityDemos.Ninth
{
    [TestClass]
    public class SectionsTests
    {
        private static App _app;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _app = new App();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _app.Dispose();
        }

        [TestMethod]
        public void Falcon9LinkAddsCorrectProduct()
        {
            var mainPage = _app.GoTo<MainPage>();

            mainPage.Assertions.AssertProductBoxLink("Falcon 9", "http://demos.bellatrix.solutions/product/falcon-9/");
        }

        [TestMethod]
        public void SaturnVLinkAddsCorrectProduct()
        {
            var mainPage = _app.GoTo<MainPage>();

            mainPage.Assertions.AssertProductBoxLink("Saturn V", "http://demos.bellatrix.solutions/product/saturn-v/");
        }
    }
}
