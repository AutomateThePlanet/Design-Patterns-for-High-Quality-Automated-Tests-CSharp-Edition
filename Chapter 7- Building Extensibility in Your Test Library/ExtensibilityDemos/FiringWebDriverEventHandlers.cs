﻿// Copyright 2024 Automate The Planet Ltd.
// Author: Anton Angelov
// Licensed under the Apache License, Version 2.0 (the "License");
// You may not use this file except in compliance with the License.
// You may obtain a copy of the License at http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
using OpenQA.Selenium.Support.Events;

namespace ExtensibilityDemos;

public abstract class FiringWebDriverEventHandlers
{
    public virtual void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
    {
    }

    public virtual void OnNavigated(object sender, WebDriverNavigationEventArgs e)
    {
    }

    public virtual void OnElementClicked(object sender, WebElementEventArgs e)
    {
    }
}
