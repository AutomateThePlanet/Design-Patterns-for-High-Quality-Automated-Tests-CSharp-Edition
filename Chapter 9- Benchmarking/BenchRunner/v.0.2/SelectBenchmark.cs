using BenchmarkDotNet.Attributes;
using BenchmarkingDemos;
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace BenchRunner.Second
{
    [ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
    public class SelectBenchmark : BenchmarkingDemos.BenchmarkCore.BaseBenchmark
    {
        private const string TestPage = "http://htmlpreview.github.io/?https://github.com/angelovstanton/AutomateThePlanet/blob/master/WebDriver-Series/TestPage.html";

        [IterationSetup(Target = nameof(BenchmarkSelectElementSelect))]
        public void IterationSetupBenchmarkSelectElementSelect()
        {
            BenchmarkInitialize();
        }

        [IterationSetup()]
        public void IterationSetup()
        {
            BenchmarkInitialize(() => 
            { 
                // execute custom setup code here 
            });
         }

        [IterationCleanup()]
        public void IterationCleanup()
        {
            BenchmarkCleanup(() =>
            {
                // execute custom setup code here 
            });
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
