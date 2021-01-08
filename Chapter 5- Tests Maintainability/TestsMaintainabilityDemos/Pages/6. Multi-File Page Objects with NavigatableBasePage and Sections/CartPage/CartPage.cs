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
namespace TestsMaintainabilityDemos.Sixth
{
    public class CartPage : NavigatableEShopPage
    {
        public CartPage(Driver driver) 
            : base(driver)
        {
            BreadcrumbSection = new BreadcrumbSection(Driver);
            Elements = new CartPageElements(driver);
        }

        public BreadcrumbSection BreadcrumbSection { get; }
        public CartPageElements Elements { get; }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";


        public void ApplyCoupon(string coupon)
        {
            Elements.CouponCodeTextField.TypeText(coupon);
            Elements.ApplyCouponButton.Click();
            Driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            Elements.QuantityBox.TypeText(newQuantity.ToString());
            Elements.UpdateCart.Click();
            Driver.WaitForAjax();
        }

        public void ProceedToCheckout()
        {
            Elements.ProceedToCheckout.Click();
            Driver.WaitUntilPageLoadsCompletely();
        }

        public string GetTotal()
        {
            return Elements.TotalSpan.Text;
        }


        public string GetMessageNotification()
        {
            return Elements.MessageAlert.Text;
        }

        protected override void WaitForPageLoad()
        {
            Elements.CouponCodeTextField.WaitToExists();
        }
    }
}
