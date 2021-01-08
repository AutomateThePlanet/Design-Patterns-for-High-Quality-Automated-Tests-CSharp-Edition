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
using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TestsMaintainabilityDemos
{
    public class LoggingDriver : DriverDecorator
    {
        public LoggingDriver(Driver driver)
            : base(driver)
        {
        }

        public override void Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            Driver?.Start(browser);
        }

        public override void Quit()
        {
            Console.WriteLine("Close browser");
            Driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            Driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine("Find Element");
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            Console.WriteLine("Find elements");
            return Driver?.FindElements(locator);
        }
    }
}
