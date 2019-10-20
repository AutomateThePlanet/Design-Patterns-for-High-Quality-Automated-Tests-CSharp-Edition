using System;
using OpenQA.Selenium.Support.Events;

namespace ExtensibilityDemos
{
    public class LoggingFiringWebDriverEventHandlers : FiringWebDriverEventHandlers
    {
        public override void OnElementClicked(object sender, WebElementEventArgs e)
        {
            Console.WriteLine(e.Element);
        }

        public override void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Console.WriteLine(e.ThrownException);
        }
    }
}
