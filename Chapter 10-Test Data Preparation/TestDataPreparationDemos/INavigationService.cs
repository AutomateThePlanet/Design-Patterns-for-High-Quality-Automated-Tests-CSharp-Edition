using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TestDataPreparationDemos
{
    public interface INavigationService
    {
        void GoToUrl(string url);
        Uri Url { get; }
    }
}
