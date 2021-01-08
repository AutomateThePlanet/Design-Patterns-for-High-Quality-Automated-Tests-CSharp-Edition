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
using System.Linq;
using System.Reflection;
using ApiUsabilityDemos.Tenth;

namespace ApiUsabilityDemos.Pages.Tenth
{
    public class App : IDisposable
    {
        private readonly Driver _driver;

        public App(Browser browserType = Browser.Chrome)
        {
            _driver = new LoggingDriver(new WebDriver());
            _driver.Start(browserType);
        }

        public void Dispose()
        {
            _driver.Quit();
        }


        public TPage Create<TPage>()
            where TPage : EShopPage
        {
            var constructor = typeof(TPage).GetTypeInfo().GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var page = constructor?.Invoke(new object[] { _driver }) as TPage;
            return page;
        }

        public TPage GoTo<TPage>()
            where TPage : NavigatableEShopPage
        {
            var constructor = typeof(TPage).GetTypeInfo().GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();
            var page = constructor?.Invoke(new object[] { _driver }) as TPage;
            page?.Open();

            return page;
        }
    }
}
