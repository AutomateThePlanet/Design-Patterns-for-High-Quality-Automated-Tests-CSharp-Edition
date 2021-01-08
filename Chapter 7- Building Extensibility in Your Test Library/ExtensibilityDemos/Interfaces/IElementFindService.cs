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
using System.Collections.Generic;
using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos
{
    public interface IElementFindService
    {
        ////Element FindElement(By locator);
        ////List<Element> FindElements(By locator);
        Element FindById(string id);
        Element FindByXPath(string xpath);
        Element FindByTag(string tag);
        Element FindByClass(string cssClass);
        Element FindByCss(string css);
        Element FindByLinkText(string linkText);
        List<Element> FindAllById(string id);
        List<Element> FindAllByXPath(string xpath);
        List<Element> FindAllByTag(string tag);
        List<Element> FindAllByClass(string cssClass);
        List<Element> FindAllByCss(string css);
        List<Element> FindAllByLinkText(string linkText);

        List<Element> FindAll(FindStrategy findStrategy);
        Element Find(FindStrategy findStrategy);
    }
}
