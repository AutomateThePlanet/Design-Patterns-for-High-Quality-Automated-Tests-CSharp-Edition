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

namespace ApiUsabilityDemos.Eight
{
    [TestClass]
    public class SectionsTests
    {
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            LoggingSingletonDriver.Instance.Start(Browser.Chrome);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            LoggingSingletonDriver.Instance.Quit();
        }

        [TestMethod]
        public void Falcon9LinkAddsCorrectProduct()
        {
            MainPage.Instance.Open();

            MainPage.Instance.Assertions.AssertProductBoxLink("Falcon 9", "http://demos.bellatrix.solutions/product/falcon-9/");
        }

        [TestMethod]
        public void SaturnVLinkAddsCorrectProduct()
        {
            MainPage.Instance.Open();

            MainPage.Instance.Assertions.AssertProductBoxLink("Saturn V", "http://demos.bellatrix.solutions/product/saturn-v/");
        }
    }
}
