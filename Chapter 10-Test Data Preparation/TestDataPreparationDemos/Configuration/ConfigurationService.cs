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
