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
using TestDataPreparationDemos.Pages.Tenth;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDataPreparationDemos.Tenth
{
    [TestClass]
    public class SectionsTests
    {
        private static App _app;

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            _app = new App();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            _app.Dispose();
        }

        [TestMethod]
        public void CompletePurchaseSuccessfully_WhenNewClient()
        {
            var mainPage = _app.GoTo<MainPage>();

            mainPage.AddRocketToShoppingCart();

            var cartPage = _app.GoTo<CartPage>();
            cartPage.ApplyCoupon("happybirthday")
                .AssertMessageNotification("Coupon code applied successfully.")
                .IncreaseProductQuantity(2)
                .AssertTotal("114.00€")
                .ProceedToCheckout();
        }
    }
}
