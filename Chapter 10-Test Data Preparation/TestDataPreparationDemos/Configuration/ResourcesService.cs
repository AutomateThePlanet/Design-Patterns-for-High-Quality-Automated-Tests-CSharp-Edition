using System.Globalization;
using System.Reflection;
using System.Resources;

namespace TestDataPreparationDemos.Configuration
{
    public static class ResourcesService
    {
        private static readonly ResourceManager ResourceManager 
            = new ResourceManager("defaultValues", Assembly.GetExecutingAssembly());

        public static string GetString(string name)
        {
            return ResourceManager.GetString(name, CultureInfo.CurrentCulture);
        }
    }
}
