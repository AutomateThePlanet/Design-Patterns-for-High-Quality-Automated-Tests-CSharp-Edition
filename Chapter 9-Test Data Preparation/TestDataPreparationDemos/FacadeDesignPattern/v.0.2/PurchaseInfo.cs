using TestDataPreparationDemos.Configuration;

namespace TestDataPreparationDemos.Facades.Second
{
    public class PurchaseInfo
    {
        public string FirstName { get; set; } = ResourcesService.GetString("firstName");
        public string LastName { get; set; } = ResourcesService.GetString("lastName");
        public string Company { get; set; } = ResourcesService.GetString("company");
        public string Country { get; set; } = ResourcesService.GetString("country");
        public string Address1 { get; set; } = ResourcesService.GetString("address1");
        public string Address2 { get; set; } = ResourcesService.GetString("address2");
        public string City { get; set; } = ResourcesService.GetString("city");
        public string Zip { get; set; } = ResourcesService.GetString("zip");
        public string Phone { get; set; } = ResourcesService.GetString("phone");
        public string Email { get; set; } = ResourcesService.GetString("email");
        public bool ShouldCreateAccount { get; set; }
        public bool ShouldCheckPayment { get; set; }
        public string Note { get; set; }
    }
}
