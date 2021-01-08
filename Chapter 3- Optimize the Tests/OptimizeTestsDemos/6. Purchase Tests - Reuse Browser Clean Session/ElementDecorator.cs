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
using OpenQA.Selenium;

namespace StabilizeTestsDemos.SixthVersion
{
    public abstract class ElementDecorator : Element
    {
        protected Element Element;

        protected ElementDecorator(Element element)
        {
            Element = element;
        }

        public override By By => Element?.By;

        public override string Text => Element?.Text;

        public override bool? Enabled => Element?.Enabled;

        public override bool? Displayed => Element?.Displayed;

        public override void Click()
        {
            Element?.Click();
        }

        public override string GetAttribute(string attributeName)
        {
            return Element?.GetAttribute(attributeName);
        }

        public override void TypeText(string text)
        {
            Element?.TypeText(text);
        }
    }
}
