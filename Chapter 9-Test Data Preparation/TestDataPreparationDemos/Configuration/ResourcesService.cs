using System.Globalization;
using System.Reflection;
using System.Resources;

namespace TestDataPreparationDemos.Configuration
{
    public static class ResourcesService
    {
        private static ResourceManager _resourceManager = new ResourceManager("defaultValues", Assembly.GetExecutingAssembly());

        public static string GetString(string name)
        {
            return _resourceManager.GetString(name, CultureInfo.CurrentCulture);
        }
    }
}
