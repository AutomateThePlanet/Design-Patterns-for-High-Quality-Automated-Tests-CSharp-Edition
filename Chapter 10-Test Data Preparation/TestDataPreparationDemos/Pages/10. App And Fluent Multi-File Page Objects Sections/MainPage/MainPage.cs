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

namespace TestDataPreparationDemos.Tenth
{
    public class MainPage : NavigatableEShopPage
    {
        private readonly MainPageElements _elements;

        private MainPage(Driver driver) 
            : base(driver)
        {
            _elements = new MainPageElements(driver);
        }

        protected override string Url => ConfigurationService.GetWebSettings().BaseUrl;

        public MainPage AddRocketToShoppingCart()
        {
            Open();
            _elements.AddToCartFalcon9.Click();
            _elements.ViewCartButton.Click();

            return this;
        }

        public MainPage AssertProductBoxLink(string name, string expectedLink)
        {
            string actualLink = _elements.GetProductBoxByName(name).GetAttribute("href");
            Assert.AreEqual(expectedLink, actualLink);
            return this;
        }

        protected override void WaitForPageLoad()
        {
            _elements.AddToCartFalcon9.WaitToExists();
        }
    }
}
