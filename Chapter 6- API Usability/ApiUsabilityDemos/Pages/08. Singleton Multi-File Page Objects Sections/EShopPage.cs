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
namespace ApiUsabilityDemos.Eight
{
    public abstract class EShopPage<TPage>
        where TPage : EShopPage<TPage>, new()
    {
        private static TPage _instance;

        protected readonly IElementFindService ElementFindService;

        protected EShopPage()
        {
            ElementFindService = LoggingSingletonDriver.Instance;
            SearchSection = new SearchSection(LoggingSingletonDriver.Instance);
            MainMenuSection = new MainMenuSection(LoggingSingletonDriver.Instance);
            CartInfoSection = new CartInfoSection(LoggingSingletonDriver.Instance);
        }

        public static TPage Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new TPage();
                }

                return _instance;
            }
        }

        public SearchSection SearchSection { get; }
        public MainMenuSection MainMenuSection { get; }
        public CartInfoSection CartInfoSection { get; }
    }
}
