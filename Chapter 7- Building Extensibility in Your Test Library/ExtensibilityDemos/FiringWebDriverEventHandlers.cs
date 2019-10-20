using OpenQA.Selenium.Support.Events;

namespace ExtensibilityDemos
{
    public abstract class FiringWebDriverEventHandlers
    {
        public virtual void OnExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
        }

        public virtual void OnNavigated(object sender, WebDriverNavigationEventArgs e)
        {
        }

        public virtual void OnElementClicked(object sender, WebElementEventArgs e)
        {
        }
    }
}
