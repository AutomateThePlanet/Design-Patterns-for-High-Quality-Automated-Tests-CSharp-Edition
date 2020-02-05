using BenchmarkDotNet.Attributes;
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BenchRunner.First
{
    public class SelectBenchmark
    {
        private const string TestPage = "http://htmlpreview.github.io/?https://github.com/angelovstanton/AutomateThePlanet/blob/master/WebDriver-Series/TestPage.html";
        private static IWebDriver _driver;

        [GlobalSetup]
        public void GlobalSetup()
        {
            _driver = new ChromeDriver(DriverExecutablePathResolver.GetDriverExecutablePath());
            _driver.Navigate().GoToUrl(TestPage);
        }

        [GlobalCleanup]
        public void GlobalCleanup()
        {
            _driver?.Dispose();
        }

        [Benchmark(Baseline = true)]
        public void BenchmarkSelectElementSelect()
        {
            var selects = _driver.FindElements(By.TagName("select"));
            foreach (var select in selects)
            {
                var selectElement = new SelectElement(select);
                selectElement.SelectByText("Mercedes");
            }
        }

        [Benchmark]
        public void BenchmarkCustomSelect()
        {
            var selects = _driver.FindElements(By.TagName("select"));
            foreach (var select in selects)
            {
                select.Click();
                var mercedesOption = select.FindElement(By.XPath("./option[@value='mercedes']"));
                mercedesOption.Click();
            }
        }
    }
}
