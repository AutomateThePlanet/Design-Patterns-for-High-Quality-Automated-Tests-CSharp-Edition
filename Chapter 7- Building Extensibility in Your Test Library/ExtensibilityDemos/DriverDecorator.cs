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
using System;
using System.Collections.Generic;
using ExtensibilityDemos.Locators;

namespace ExtensibilityDemos;

public abstract class DriverDecorator : Driver
{
    protected Driver Driver;

    protected DriverDecorator(Driver driver)
    {
        Driver = driver;
    }

    public override Uri Url => Driver?.Url;

    public override void Start(Browser browser)
    {
        Driver?.Start(browser);
    }

    public override void Quit()
    {
        Driver?.Quit();
    }

    public override void GoToUrl(string url)
    {
        Driver?.GoToUrl(url);
    }

    ////public override Element FindElement(By locator)
    ////{
    ////    return Driver?.FindElement(locator);
    ////}

    ////public override List<Element> FindElements(By locator)
    ////{
    ////    return Driver?.FindElements(locator);
    ////}

    public override void WaitForAjax()
    {
        Driver?.WaitForAjax();
    }

    public override void WaitUntilPageLoadsCompletely()
    {
        Driver?.WaitUntilPageLoadsCompletely();
    }

    public override Element FindById(string id)
    {
        return Driver?.FindById(id);
    }

    public override Element FindByXPath(string xpath)
    {
        return Driver?.FindByXPath(xpath);
    }

    public override Element FindByTag(string tag)
    {
        return Driver?.FindByTag(tag);
    }

    public override Element FindByClass(string cssClass)
    {
        return Driver?.FindByClass(cssClass);
    }

    public override Element FindByCss(string css)
    {
        return Driver?.FindByCss(css);
    }

    public override Element FindByLinkText(string linkText)
    {
        return Driver?.FindByLinkText(linkText);
    }

    public override List<Element> FindAllById(string id)
    {
        return Driver?.FindAllById(id);
    }

    public override List<Element> FindAllByXPath(string xpath)
    {
        return Driver?.FindAllByXPath(xpath);
    }

    public override List<Element> FindAllByTag(string tag)
    {
        return Driver?.FindAllByTag(tag);
    }

    public override List<Element> FindAllByClass(string cssClass)
    {
        return Driver?.FindAllByClass(cssClass);
    }

    public override List<Element> FindAllByCss(string css)
    {
        return Driver?.FindAllByCss(css);
    }

    public override List<Element> FindAllByLinkText(string linkText)
    {
        return Driver?.FindAllByLinkText(linkText);
    }

    public override List<Element> FindAll(FindStrategy findStrategy)
    {
        return Driver?.FindAll(findStrategy);
    }

    public override Element Find(FindStrategy findStrategy)
    {
        return Driver?.Find(findStrategy);
    }

    public override void Wait(Element element, WaitStrategy waitStrategy)
    {
        Driver?.Wait(element, waitStrategy);
    }
}
