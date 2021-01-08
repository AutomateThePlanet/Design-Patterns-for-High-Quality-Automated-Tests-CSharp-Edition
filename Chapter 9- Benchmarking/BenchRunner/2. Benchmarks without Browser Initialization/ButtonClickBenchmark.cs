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
using BenchmarkDotNet.Attributes;
using BenchmarkingDemos;
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BenchRunner.Second
{
    [ExecutionBrowser(Browser.Chrome, BrowserBehavior.ReuseIfStarted)]
    public class ButtonClickBenchmark : BenchmarkingDemos.BenchmarkCore.BaseBenchmark
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

        [IterationSetup()]
        public void IterationSetup()
        {
            BenchmarkInitialize();
        }

        [IterationCleanup()]
        public void IterationCleanup()
        {
            BenchmarkCleanup();
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
