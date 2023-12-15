// Copyright 2024 Automate The Planet Ltd.
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
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BenchRunner.Second;

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
