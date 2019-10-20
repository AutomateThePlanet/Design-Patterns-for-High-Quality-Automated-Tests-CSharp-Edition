using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ExtensibilityDemos
{
    public interface INavigationService
    {
        void GoToUrl(string url);
        Uri Url { get; }
    }
}
