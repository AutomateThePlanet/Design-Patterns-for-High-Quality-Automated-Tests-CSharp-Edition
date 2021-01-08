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

namespace TestsMaintainabilityDemos.Second
{
    public abstract class BaseEShopPage
    {
        protected readonly Driver Driver;

        protected BaseEShopPage(Driver driver)
        {
            Driver = driver;
        }

        protected abstract string Url { get; }

        private Element SearchField => Driver.FindElement(By.Id("woocommerce-product-search-field-0"));
        private Element HomeLink => Driver.FindElement(By.LinkText("Home"));
        private Element BlogLink => Driver.FindElement(By.LinkText("Blog"));
        private Element CartLink => Driver.FindElement(By.LinkText("Cart"));
        private Element CheckoutLink => Driver.FindElement(By.LinkText("Cart"));
        private Element MyAccountLink => Driver.FindElement(By.LinkText("My Account"));
        private Element PromotionsLink => Driver.FindElement(By.LinkText("Promotions"));
        private Element CartIcon => Driver.FindElement(By.ClassName("cart-contents"));
        private Element CartAmount => Driver.FindElement(By.ClassName("amount"));
        private Element Breadcrumb => Driver.FindElement(By.ClassName("woocommerce-breadcrumb"));

        public void Open()
        {
            Driver.GoToUrl(Url);
        }

        public void SearchForItem(string searchText)
        {
            SearchField.TypeText(searchText);
        }

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

        public string GetCurrentAmount()
        {
            return CartAmount.Text;
        }

        public void OpenCart()
        {
            CartIcon.Click();
        }

        public void OpenBreadcrumbItem(string itemToOpen)
        {
            Breadcrumb.FindElement(By.LinkText(itemToOpen)).Click();
        }
    }
}
