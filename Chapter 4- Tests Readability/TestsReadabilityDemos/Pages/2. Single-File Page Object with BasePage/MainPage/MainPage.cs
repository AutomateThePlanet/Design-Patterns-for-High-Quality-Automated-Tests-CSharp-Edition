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
using OpenQA.Selenium;

namespace TestsReadabilityDemos.Second
{
    public class MainPage : BaseEShopPage
    {
        public MainPage(Driver driver) 
            : base(driver)
        {
        }
        protected override string Url => "http://demos.bellatrix.solutions/";

        private Element AddToCartFalcon9 => Driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element ViewCartButton => Driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));


        public void AddRocketToShoppingCart()
        {
            Open();
            AddToCartFalcon9.Click();
            ViewCartButton.Click();
        }
    }
}
