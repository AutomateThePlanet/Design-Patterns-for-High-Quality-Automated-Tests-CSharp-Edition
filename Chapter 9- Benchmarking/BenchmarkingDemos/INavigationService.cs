using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace BenchmarkingDemos
{
    public interface INavigationService
    {
        void GoToUrl(string url);
        Uri Url { get; }
    }
}
