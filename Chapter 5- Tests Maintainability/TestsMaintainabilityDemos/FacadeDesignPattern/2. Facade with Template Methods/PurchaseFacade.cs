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
    public abstract class PurchaseFacade
    {
        public void PurchaseItem(string rocketName, string couponName, int quantity, string expectedPrice, PurchaseInfo purchaseInfo)
        {
            AddItemToShoppingCart(rocketName);
            ApplyCoupon(couponName);
            AssertCouponAppliedSuccessfully();
            IncreaseProductQuantity(quantity);
            AssertTotalPrice(expectedPrice);
            ProceedToCheckout();
            FillBillingInfo(purchaseInfo);
            AssertOrderReceived();
        }

        protected abstract void AddItemToShoppingCart(string itemName);
        protected abstract void ApplyCoupon(string couponName);
        protected abstract void AssertCouponAppliedSuccessfully();
        protected abstract void IncreaseProductQuantity(int quantity);
        protected abstract void AssertTotalPrice(string expectedPrice);
        protected abstract void ProceedToCheckout();
        protected abstract void FillBillingInfo(PurchaseInfo purchaseInfo);
        protected abstract void AssertOrderReceived();
    }
}
