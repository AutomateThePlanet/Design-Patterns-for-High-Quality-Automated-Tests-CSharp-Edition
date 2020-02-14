using TestDataPreparationDemos.Configuration;

namespace TestDataPreparationDemos.Facades.Second
{
    public class PurchaseInfo
    {
        public string FirstName { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().FirstName;
        public string LastName { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().LastName;
        public string Company { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Company;
        public string Country { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Country;
        public string Address1 { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Address1;
        public string Address2 { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Address2;
        public string City { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().City;
        public string Zip { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Zip;
        public string Phone { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Phone;
        public string Email { get; set; } =
            ConfigurationService.GetBillingInfoDefaultValues().Email;
        public bool ShouldCreateAccount { get; set; }
        public bool ShouldCheckPayment { get; set; }
        public string Note { get; set; }
    }
}
