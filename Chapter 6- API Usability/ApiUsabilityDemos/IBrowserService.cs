namespace ApiUsabilityDemos
{
    public interface IBrowserService
    {
        void WaitForAjax();
        void WaitUntilPageLoadsCompletely();
        void Start(Browser browser);
        void Quit();
    }
}
