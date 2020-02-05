using Flurl;

namespace TestDataPreparationDemos.Configuration
{
    public static class UrlDeterminer
    {
        public static string GetShopUrl(string urlPart)
        {
            return Url.Combine(ConfigurationService.GetTestEnvironmentSettings().ShopUrl, urlPart);
        }

        public static string GetAccountUrl(string urlPart)
        {
            return Url.Combine(ConfigurationService.GetTestEnvironmentSettings().AccountUrl, urlPart);
        }
    }
}
