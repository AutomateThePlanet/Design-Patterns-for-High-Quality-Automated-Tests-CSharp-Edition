using System;

namespace StabilizeTestsDemos.SixthVersion
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class ExecutionBrowserAttribute : Attribute
    {
        public ExecutionBrowserAttribute(Browser browser, BrowserBehavior browserBehavior)
        {
            BrowserConfiguration = new BrowserConfiguration(browser, browserBehavior);
        }

        public BrowserConfiguration BrowserConfiguration { get; set; }
    }
}