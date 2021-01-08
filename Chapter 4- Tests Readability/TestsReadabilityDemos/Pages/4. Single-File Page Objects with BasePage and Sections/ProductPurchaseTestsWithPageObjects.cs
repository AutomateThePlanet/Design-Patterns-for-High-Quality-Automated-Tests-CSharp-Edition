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

namespace TestsReadabilityDemos.Fourth
{
    [TestClass]
    public class SectionsTests
    {
        private static Driver _driver;
        private static MainPage _mainPage;
        private static CartPage _cartPage;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(Browser.Chrome);
            _mainPage = new MainPage(_driver);
            _cartPage = new CartPage(_driver);
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _driver.Quit();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _mainPage.Open();
        }

        [TestMethod]
        public void OpenBlogPage()
        {
            _mainPage.MainMenuSection.OpenBlogPage();
            // verify page title
        }

        [TestMethod]
        public void SearchForItem()
        {
            _mainPage.SearchSection.SearchForItem("Falcon 9");
            // add the item to cart
        }

        [TestMethod]
        public void OpenCart()
        {
            _mainPage.CartInfoSection.OpenCart();
            // verify items in the cart
        }
    }
}
