namespace StabilizeTestsDemos.FifthVersion
{
    public class BrowserConfiguration
    {
        public BrowserConfiguration()
        {
            Browser = Browser.NotSet;
            BrowserBehavior = BrowserBehavior.RestartEveryTime;
        }

        public BrowserConfiguration(Browser browser, BrowserBehavior browserBehavior)
        {
            Browser = browser;
            BrowserBehavior = browserBehavior;
        }

        public Browser Browser { get; set; }
        public BrowserBehavior BrowserBehavior { get; set; }
    }
}
