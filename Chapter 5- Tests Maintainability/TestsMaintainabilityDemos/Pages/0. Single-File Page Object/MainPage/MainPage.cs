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

namespace TestsMaintainabilityDemos
{
    public class MainPage
    {
        private readonly Driver _driver;
        private readonly string _url = "http://demos.bellatrix.solutions/";

        public MainPage(Driver driver)
        {
            _driver = driver;
        }

        private Element AddToCartFalcon9 => _driver.FindElement(By.CssSelector("[data-product_id*='28']"));
        private Element ViewCartButton => _driver.FindElement(By.CssSelector("[class*='added_to_cart wc-forward']"));

        public void AddRocketToShoppingCart()
        {
            _driver.GoToUrl(_url);
            AddToCartFalcon9.Click();
            ViewCartButton.Click();
        }
    }
}
