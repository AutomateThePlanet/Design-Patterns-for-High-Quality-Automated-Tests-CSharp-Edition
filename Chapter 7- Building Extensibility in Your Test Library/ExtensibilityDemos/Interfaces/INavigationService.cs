using System;

namespace ExtensibilityDemos
{
    public interface INavigationService
    {
        void GoToUrl(string url);
        Uri Url { get; }
    }
}