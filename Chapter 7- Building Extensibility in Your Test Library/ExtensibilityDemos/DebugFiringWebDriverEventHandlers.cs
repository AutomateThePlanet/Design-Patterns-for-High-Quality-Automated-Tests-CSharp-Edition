using System.Diagnostics;
using OpenQA.Selenium.Support.Events;

namespace ExtensibilityDemos
{
    public class DebugFiringWebDriverEventHandlers : FiringWebDriverEventHandlers
    {
        public override void OnElementClicked(object sender, WebElementEventArgs e)
        {
            Debug.WriteLine($"Click on element with tag name = {e.Element.TagName}");
        }

        public override void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            Debug.WriteLine(e.ThrownException);
        }
    }
}