using BenchmarkDotNet.Attributes;
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BenchRunner.First
{
    public class ButtonClickBenchmark
    {
        private const string TestPage = "http://htmlpreview.github.io/?https://github.com/angelovstanton/AutomateThePlanet/blob/master/WebDriver-Series/TestPage.html";
        private static IWebDriver _driver;
        private static IJavaScriptExecutor _javaScriptExecutor;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _driver = new ChromeDriver(DriverExecutablePathResolver.GetDriverExecutablePath());
            _javaScriptExecutor = (IJavaScriptExecutor)_driver;
            _driver.Navigate().GoToUrl(TestPage);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _driver?.Dispose();
        }

        [Benchmark(Baseline = true)]
        public void BenchmarkWebDriverClick()
        {
            var buttons = _driver.FindElements(By.XPath("//input[@value='Submit']"));
            foreach (var button in buttons)
            {
                button.Click();
            }
        }

        [Benchmark]
        public void BenchmarkJavaScriptClick()
        {
            var buttons = _driver.FindElements(By.XPath("//input[@value='Submit']"));
            foreach (var button in buttons)
            {
                _javaScriptExecutor.ExecuteScript("arguments[0].click();", button);
            }
        }
    }
}
