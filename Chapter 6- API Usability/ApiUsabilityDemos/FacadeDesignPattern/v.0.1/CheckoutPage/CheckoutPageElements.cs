using OpenQA.Selenium;

namespace ApiUsabilityDemos.Facades.First
{
    public class CheckoutPageElements
    {
        private readonly Driver _driver;

        public CheckoutPageElements(Driver driver) => _driver = driver;

        public Element BillingFirstName => _driver.FindElement(By.Id("billing_first_name"));
        public Element BillingLastName => _driver.FindElement(By.Id("billing_last_name"));
        public Element BillingCompany => _driver.FindElement(By.Id("billing_company"));
        public Element BillingCountryWrapper => _driver.FindElement(By.Id("billing_country"));
        public Element BillingCountryFilter => _driver.FindElement(By.Id("search__field"));
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
