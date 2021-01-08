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
    public class CartPage : BaseEShopPage
    {
        public CartPage(Driver driver)
            : base(driver)
        {
        }

        protected override string Url => "http://demos.bellatrix.solutions/cart/";

        private Element CouponCodeTextField => Driver.FindElement(By.Id("coupon_code"));
        private Element ApplyCouponButton => Driver.FindElement(By.CssSelector("[value*='Apply coupon']"));
        private Element QuantityBox => Driver.FindElement(By.CssSelector("[class*='input-text qty text']"));
        private Element UpdateCart => Driver.FindElement(By.CssSelector("[value*='Update cart']"));
        private Element MessageAlert => Driver.FindElement(By.CssSelector("[class*='woocommerce-message']"));
        private Element TotalSpan => Driver.FindElement(By.XPath("//*[@class='order-total']//span"));
        private Element ProceedToCheckout => Driver.FindElement(By.CssSelector("[class*='checkout-button button alt wc-forward']"));

        public void ApplyCoupon(string coupon)
        {
            CouponCodeTextField.TypeText(coupon);
            ApplyCouponButton.Click();
            Driver.WaitForAjax();
        }

        public void IncreaseProductQuantity(int newQuantity)
        {
            QuantityBox.TypeText(newQuantity.ToString());
            UpdateCart.Click();
            Driver.WaitForAjax();
        }

        public void ClickProceedToCheckout()
        {
            ProceedToCheckout.Click();
            Driver.WaitUntilPageLoadsCompletely();
        }

        public string GetTotal()
        {
            return TotalSpan.Text;
        }

        public string GetMessageNotification()
        {
            return MessageAlert.Text;
        }
    }
}
