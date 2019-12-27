using BenchmarkDotNet.Attributes;
using BenchmarkingDemos;
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BenchRunner.Second
{
    [ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
    public class SelectBenchmark : BaseBenchmark
    {
        private const string TestPage = "http://htmlpreview.github.io/?https://github.com/angelovstanton/AutomateThePlanet/blob/master/WebDriver-Series/TestPage.html";

        [IterationSetup(Target = nameof(BenchmarkSelectElementSelect))]
        public void IterationSetupBenchmarkSelectElementSelect()
        {
            BenchmarkInitialize();
        }

        [IterationSetup(Target = nameof(BenchmarkCustomSelect))]
        public void IterationSetupBenchmarkCustomSelect()
        {
            BenchmarkInitialize();
        }

        [IterationCleanup(Target = nameof(BenchmarkSelectElementSelect))]
        public void IterationCleanupBenchmarkSelectElementSelect()
        {
            BenchmarkCleanup();
        }

        [IterationCleanup(Target = nameof(BenchmarkCustomSelect))]
        public void IterationCleanupGetCellByRowAndColumn()
        {
            BenchmarkCleanup();
        }

        [Benchmark(Baseline = true)]
        public void BenchmarkSelectElementSelect()
        {
            Driver.GoToUrl(TestPage);
            var selects = Driver.FindElements(By.TagName("select"));
            foreach (var select in selects)
            {
                var selectElement = new SelectElement(select.WrappedElement);
                selectElement.SelectByText("Mercedes");
            }
        }

        [Benchmark]
        public void BenchmarkCustomSelect()
        {
            Driver.GoToUrl(TestPage);
            var selects = Driver.FindElements(By.TagName("select"));
            foreach (var select in selects)
            {
                select.Click();
                var mercedesOption = select.FindElement(By.XPath("./option[@value='mercedes']"));
                mercedesOption.Click();
            }
        }
    }
}
