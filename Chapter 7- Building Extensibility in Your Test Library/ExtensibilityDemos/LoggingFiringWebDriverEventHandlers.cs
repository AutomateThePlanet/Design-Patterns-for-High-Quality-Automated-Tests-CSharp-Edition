using System;
using OpenQA.Selenium.Support.Events;

namespace ExtensibilityDemos
{
    public class LoggingFiringWebDriverEventHandlers : FiringWebDriverEventHandlers
    {
        public override void OnElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine($"Click on element with tag= {e.Element.TagName}");
        }

        public override void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine($"Exception thrown= {e.ThrownException}");
        }
    }
}
