using System.IO;
using System.Reflection;

namespace BenchmarkingDemos.BenchmarkCore
{
    public static class DriverExecutablePathResolver
    {
        public static string GetDriverExecutablePath()
        {
            string assemblyFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var directoryInfo = new DirectoryInfo(assemblyFolder);
            for (int i = 0; i < 4; i++)
            {
                directoryInfo = directoryInfo.Parent;
            }

            return directoryInfo.FullName;
        }
    }
}
