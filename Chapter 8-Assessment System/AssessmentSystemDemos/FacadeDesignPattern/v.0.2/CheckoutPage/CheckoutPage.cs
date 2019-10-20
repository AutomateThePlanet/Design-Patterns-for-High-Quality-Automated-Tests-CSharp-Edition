namespace AssessmentSystemDemos.Facades.Second
{
    public class CheckoutPage : EShopPage
    {
        public CheckoutPage(Driver driver) : base(driver)
        {
            CheckoutPageElements = new CheckoutPageElements(driver);
            CheckoutPageAssertions = new CheckoutPageAssertions(CheckoutPageElements);
        }

        public CheckoutPageElements CheckoutPageElements { get; set; }
        public CheckoutPageAssertions CheckoutPageAssertions { get; set; }

        public void FillBillingInfo(PurchaseInfo purchaseInfo)
        {
            CheckoutPageElements.BillingFirstName.TypeText(purchaseInfo.FirstName);
            CheckoutPageElements.BillingLastName.TypeText(purchaseInfo.LastName);
            CheckoutPageElements.BillingCompany.TypeText(purchaseInfo.Company);
            CheckoutPageElements.BillingCountryWrapper.Click();
            CheckoutPageElements.BillingCountryFilter.TypeText(purchaseInfo.Country);
            CheckoutPageElements.GetCountryOptionByName(purchaseInfo.Country).Click();
            CheckoutPageElements.BillingAddress1.TypeText(purchaseInfo.Address1);
            CheckoutPageElements.BillingAddress2.TypeText(purchaseInfo.Address2);
            CheckoutPageElements.BillingCity.TypeText(purchaseInfo.City);
            CheckoutPageElements.BillingZip.TypeText(purchaseInfo.Zip);
            CheckoutPageElements.BillingPhone.TypeText(purchaseInfo.Phone);
            CheckoutPageElements.BillingEmail.TypeText(purchaseInfo.Email);
            if (purchaseInfo.ShouldCreateAccount)
            {
                CheckoutPageElements.CreateAccountCheckBox.Click();
            }

            if (purchaseInfo.ShouldCheckPayment)
            {
                CheckoutPageElements.CheckPaymentsRadioButton.Click();
            }

            CheckoutPageElements.PlaceOrderButton.Click();
            Driver.WaitForAjax();
        }
    }
}