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
namespace TestDataPreparationDemos.Facades.First
{
    public class PurchaseFacade
    {
        private readonly MainPage _mainPage;
        private readonly CartPage _cartPage;
        private readonly CheckoutPage _checkoutPage;

        public PurchaseFacade(MainPage mainPage, CartPage cartPage, CheckoutPage checkoutPage)
        {
            _mainPage = mainPage;
            _cartPage = cartPage;
            _checkoutPage = checkoutPage;
        }

        public void PurchaseItem(string rocketName, string couponName, int quantity, string expectedPrice, PurchaseInfo purchaseInfo)
        {
            _mainPage.Open();
            _mainPage.AddRocketToShoppingCart(rocketName);
            _cartPage.ApplyCoupon(couponName);
            _cartPage.Assertions.AssertCouponAppliedSuccessfully();
            _cartPage.IncreaseProductQuantity(quantity);
            _cartPage.Assertions.AssertTotalPrice(expectedPrice);
            _cartPage.ClickProceedToCheckout();
            _checkoutPage.FillBillingInfo(purchaseInfo);
            _checkoutPage.Assertions.AssertOrderReceived();
        }
    }
}
