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
    public class CheckoutPage : EShopPage
    {
        public CheckoutPage(Driver driver) 
            : base(driver)
        {
            Elements = new CheckoutPageElements(driver);
            Assertions = new CheckoutPageAssertions(Elements);
        }

        public CheckoutPageElements Elements { get; set; }
        public CheckoutPageAssertions Assertions { get; set; }

        public void FillBillingInfo(PurchaseInfo purchaseInfo)
        {
            Elements.BillingFirstName.TypeText(purchaseInfo.FirstName);
            Elements.BillingLastName.TypeText(purchaseInfo.LastName);
            Elements.BillingCompany.TypeText(purchaseInfo.Company);
            Elements.BillingCountryWrapper.Click();
            Elements.BillingCountryFilter.TypeText(purchaseInfo.Country);
            Elements.GetCountryOptionByName(purchaseInfo.Country).Click();
            Driver.WaitForAjax();
            Elements.BillingAddress1.TypeText(purchaseInfo.Address1);
            Elements.BillingAddress2.TypeText(purchaseInfo.Address2);
            Elements.BillingCity.TypeText(purchaseInfo.City);
            Elements.BillingZip.TypeText(purchaseInfo.Zip);
            Elements.BillingPhone.TypeText(purchaseInfo.Phone);
            Elements.BillingEmail.TypeText(purchaseInfo.Email);
            if (purchaseInfo.ShouldCreateAccount)
            {
                Elements.CreateAccountCheckBox.Click();
            }

            if (purchaseInfo.ShouldCheckPayment)
            {
                Elements.CheckPaymentsRadioButton.Click();
            }

            Elements.PlaceOrderButton.Click();
            Driver.WaitForAjax();
        }
    }
}
