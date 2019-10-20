using Microsoft.Extensions.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using TestDataPreparationDemos.Configuration;

namespace TestDataPreparationDemos
{
    public sealed class ConfigurationService
    {
        private static ConfigurationService _instance;

        public ConfigurationService() => Root = InitializeConfiguration();

        public static ConfigurationService Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ConfigurationService();
                }

                return _instance;
            }
        }

        public IConfigurationRoot Root { get; }

        public UrlSettings GetTestEnvironmentSettings()
        {
            var result = ConfigurationService.Instance.Root.GetSection("urlSettings").Get<UrlSettings>();

            if (result == null)
            {
                throw new ConfigurationNotFoundException(typeof(UrlSettings).ToString());
            }

            return result;
        }

        public WebSettings GetWebSettings()
         => ConfigurationService.Instance.Root.GetSection("webSettings").Get<WebSettings>();

        private IConfigurationRoot InitializeConfiguration()
        {
            var filesInExecutionDir = Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            var settingsFile =
                filesInExecutionDir.FirstOrDefault(x => x.Contains("testFrameworkSettings") && x.EndsWith(".json"));
            var builder = new ConfigurationBuilder();
            if (settingsFile != null)
            {
                builder.AddJsonFile(settingsFile, optional: true, reloadOnChange: true);
            }

            return builder.Build();
        }
    }
}
