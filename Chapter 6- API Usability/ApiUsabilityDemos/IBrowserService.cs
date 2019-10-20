namespace ApiUsabilityDemos
{
    public interface IBrowserService
    {
        void WaitForAjax();
        void WaitForJavaScriptAnimations();
        void WaitUntilPageLoadsCompletely();
        void Start(Browser browser);
        void Quit();
    }
}
