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
using BenchmarkingDemos.BenchmarkCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using WebDriverManager.DriverConfigs.Impl;

namespace BenchRunner.First;

public class SelectBenchmark
{
    private const string TestPage = "http://htmlpreview.github.io/?https://github.com/angelovstanton/AutomateThePlanet/blob/master/WebDriver-Series/TestPage.html";
    private static IWebDriver _driver;

    [GlobalSetup]
    public void GlobalSetup()
    {
        new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
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
