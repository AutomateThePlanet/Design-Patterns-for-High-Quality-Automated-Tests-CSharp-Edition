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