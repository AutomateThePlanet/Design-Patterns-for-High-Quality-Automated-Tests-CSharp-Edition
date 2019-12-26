namespace TestDataPreparationDemos.Configuration
{
    public sealed class WebSettings
    {
        public string BaseUrl { get; set; }
        public BrowserSettings Chrome { get; set; }
        public BrowserSettings Firefox { get; set; }
        public BrowserSettings Edge { get; set; }
        public BrowserSettings Opera { get; set; }
        public BrowserSettings InternetExplorer { get; set; }
        public BrowserSettings Safari { get; set; }
        public int ElementWaitTimeout { get; set; }
    }
}
