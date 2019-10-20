using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ApiUsabilityDemos
{
    public interface INavigationService
    {
        void GoToUrl(string url);
        Uri Url { get; }
    }
}
