using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using TestDataPreparationDemos.Configuration;

namespace TestDataPreparationDemos
{
    public static class ConfigurationService
    {
        private static readonly IConfigurationRoot Root = InitializeConfiguration();

        public static UrlSettings GetTestEnvironmentSettings()
        {
            var result = Root.GetSection("urlSettings").Get<UrlSettings>();

            if (result == null)
            {
                throw new ConfigurationNotFoundException(typeof(UrlSettings).ToString());
            }

            return result;
        }

        public static BillingInfoDefaultValues GetBillingInfoDefaultValues()
        {
            var result = Root.GetSection("billingInfoDefaultValues").Get<BillingInfoDefaultValues>();
            return result;
        }


        public static WebSettings GetWebSettings()
        {
            return Root.GetSection("webSettings").Get<WebSettings>();
        }

        private static IConfigurationRoot InitializeConfiguration()
        {
            var filesInExecutionDir = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var settingsFile = filesInExecutionDir.FirstOrDefault(x => x.Contains("testFrameworkSettings") && x.EndsWith(".json"));
            var builder = new ConfigurationBuilder();
            if (settingsFile != null)
            {
                builder.AddJsonFile(settingsFile, optional: true, reloadOnChange: true);
            }

            return builder.Build();
        }
    }
}
