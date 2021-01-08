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

namespace ApiUsabilityDemos.Tenth
{
    public class CartPage : NavigatableEShopPage
    {
        private readonly CartPageElements _elements;

        private CartPage(Driver driver) 
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            _elements = new CartPageElements(driver);
        }

        public BreadcrumbSection BreadcrumbSection { get; }
        protected override string Url => "http://demos.bellatrix.solutions/cart/";


        public CartPage ApplyCoupon(string coupon)
        {
            _elements.CouponCodeTextField.TypeText(coupon);
            _elements.ApplyCouponButton.Click();
            Driver.WaitForAjax();
            return this;
        }

        public CartPage IncreaseProductQuantity(int newQuantity)
        {
            _elements.QuantityBox.TypeText(newQuantity.ToString());
            _elements.UpdateCart.Click();
            Driver.WaitForAjax();
            return this;
        }

        public CartPage ProceedToCheckout()
        {
            _elements.ProceedToCheckout.Click();
            Driver.WaitUntilPageLoadsCompletely();
            return this;
        }

        public CartPage AssertTotal(string expectedTotal)
        {
            Assert.AreEqual(_elements.TotalSpan.Text, expectedTotal);
            return this;
        }

        public CartPage AssertMessageNotification(string expectedMessage)
        {
            Assert.AreEqual(_elements.MessageAlert.Text, expectedMessage);
            return this;
        }

        protected override void WaitForElementToDisplay()
        {
            _elements.CouponCodeTextField.WaitToExists();
        }
    }
}
