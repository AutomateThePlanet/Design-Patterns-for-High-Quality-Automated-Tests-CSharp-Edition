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
namespace TestsMaintainabilityDemos.Facades.Second
{
    public class NewPurchaseFacade : PurchaseFacade
    {
        private readonly MainPage _mainPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;

        public NewPurchaseFacade(MainPage mainPage, CartPage cartPage, CheckoutPage checkoutPage)
        {
            _mainPage = mainPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
        }

        protected override void AddItemToShoppingCart(string itemName)
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart(itemName);
        }

        protected override void ApplyCoupon(string couponName)
        {
            _cartPage.ApplyCoupon(couponName);
        }

        protected override void AssertCouponAppliedSuccessfully()
        {
            _cartPage.Assertions.AssertCouponAppliedSuccessfully();
        }

        protected override void AssertOrderReceived()
        {
            _checkoutPage.Assertions.AssertOrderReceived();
        }

        protected override void AssertTotalPrice(string expectedPrice)
        {
            _cartPage.Assertions.AssertTotalPrice(expectedPrice);
        }

        protected override void FillBillingInfo(PurchaseInfo purchaseInfo)
        {
            _checkoutPage.FillBillingInfo(purchaseInfo);
        }

        protected override void IncreaseProductQuantity(int quantity)
        {
            _cartPage.IncreaseProductQuantity(quantity);
        }

        protected override void ProceedToCheckout()
        {
            _cartPage.ClickProceedToCheckout();
        }
    }
}
