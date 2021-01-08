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

namespace TestsMaintainabilityDemos.Facades.Second
{
    public class CheckoutPageElements
    {
        private readonly Driver _driver;

        public CheckoutPageElements(Driver driver)
        {
            _driver = driver;
        }

        public Element BillingFirstName => _driver.FindElement(By.Id("billing_first_name"));
        public Element BillingLastName => _driver.FindElement(By.Id("billing_last_name"));
        public Element BillingCompany => _driver.FindElement(By.Id("billing_company"));
        public Element BillingCountryWrapper => _driver.FindElement(By.Id("select2-billing_country-container"));
        public Element BillingCountryFilter => _driver.FindElement(By.ClassName("select2-search__field"));
        public Element BillingAddress1 => _driver.FindElement(By.Id("billing_address_1"));
        public Element BillingAddress2 => _driver.FindElement(By.Id("billing_address_2"));
        public Element BillingCity => _driver.FindElement(By.Id("billing_city"));
        public Element BillingZip => _driver.FindElement(By.Id("billing_postcode"));
        public Element BillingPhone => _driver.FindElement(By.Id("billing_phone"));
        public Element BillingEmail => _driver.FindElement(By.Id("billing_email"));
        public Element CreateAccountCheckBox => _driver.FindElement(By.Id("createaccount"));
        public Element CheckPaymentsRadioButton => _driver.FindElement(By.CssSelector("[for*='payment_method_cheque']"));
        public Element PlaceOrderButton => _driver.FindElement(By.Id("place_order"));
        public Element ReceivedMessage => _driver.FindElement(By.XPath("//h1"));

        public Element GetCountryOptionByName(string countryName)
        {
            return _driver.FindElement(By.XPath($"//*[contains(text(),'{countryName}')]"));
        }
    }
}
