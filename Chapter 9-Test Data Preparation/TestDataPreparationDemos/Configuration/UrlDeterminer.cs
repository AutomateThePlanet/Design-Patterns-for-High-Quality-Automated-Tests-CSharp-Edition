using Flurl;

namespace TestDataPreparationDemos.Configuration
{
    public static class UrlDeterminer
    {
        public static string GetShopUrl(string urlPart)
        {
            return Url.Combine(ConfigurationService.Instance.GetTestEnvironmentSettings().ShopUrl, urlPart).ToString();
        }

        public static string GetAccountUrl(string urlPart)
        {
            return Url.Combine(ConfigurationService.Instance.GetTestEnvironmentSettings().AccountUrl, urlPart).ToString();
        }
    }
}
