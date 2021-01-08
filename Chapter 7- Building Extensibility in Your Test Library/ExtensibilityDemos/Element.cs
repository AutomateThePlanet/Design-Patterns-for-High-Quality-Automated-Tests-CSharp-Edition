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
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public abstract class Element 
    {
        public abstract By By { get; }
        public abstract string Text { get; }
        public abstract bool? Enabled { get; }
        public abstract bool? Displayed { get; }
        public abstract void TypeText(string text);
        public abstract void Click();
        public abstract string GetAttribute(string attributeName);
        public abstract void WaitToExists();
        ////public abstract Element FindElement(By locator);

        public abstract Element FindById(string id);
        public abstract Element FindByXPath(string xpath);
        public abstract Element FindByTag(string tag);
        public abstract Element FindByClass(string cssClass);
        public abstract Element FindByCss(string css);
        public abstract Element FindByLinkText(string linkText);
        public abstract List<Element> FindAllById(string id);
        public abstract List<Element> FindAllByXPath(string xpath);
        public abstract List<Element> FindAllByTag(string tag);
        public abstract List<Element> FindAllByClass(string cssClass);
        public abstract List<Element> FindAllByCss(string css);
        public abstract List<Element> FindAllByLinkText(string linkText);

        public abstract List<Element> FindAll(FindStrategy findStrategy);
        public abstract Element Find(FindStrategy findStrategy);
    }
}
