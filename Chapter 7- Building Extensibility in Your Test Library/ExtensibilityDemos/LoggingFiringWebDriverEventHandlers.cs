using System;
using OpenQA.Selenium.Support.Events;

namespace ExtensibilityDemos
{
    public class LoggingFiringWebDriverEventHandlers : FiringWebDriverEventHandlers
    {
        public override void OnElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine($"Clicking on element with tag name: {e.Element.TagName}");
        }

        public override void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine($"Exception thrown= {e.ThrownException}");
        }
    }
}