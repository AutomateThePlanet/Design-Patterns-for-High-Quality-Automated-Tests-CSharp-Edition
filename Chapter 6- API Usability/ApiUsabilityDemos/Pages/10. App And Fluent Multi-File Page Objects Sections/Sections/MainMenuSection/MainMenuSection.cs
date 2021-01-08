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

namespace ApiUsabilityDemos.Tenth
{
    public class MainMenuSection
    {
        private readonly Driver _driver;

        public MainMenuSection(Driver driver)
        {
            _driver = driver;
        }

        private Element HomeLink => _driver.FindElement(By.LinkText("Home"));
        private Element BlogLink => _driver.FindElement(By.LinkText("Blog"));
        private Element CartLink => _driver.FindElement(By.LinkText("Cart"));
        private Element CheckoutLink => _driver.FindElement(By.LinkText("Checkout"));
        private Element MyAccountLink => _driver.FindElement(By.LinkText("My Account"));
        private Element PromotionsLink => _driver.FindElement(By.LinkText("Promotions"));
        
        public void OpenHomePage()
        {
            HomeLink.Click();
        }

        public void OpenBlogPage()
        {
            BlogLink.Click();
        }

        public void OpenMyAccountPage()
        {
            MyAccountLink.Click();
        }

        public void OpenPromotionsPage()
        {
            PromotionsLink.Click();
        }
    }
}
