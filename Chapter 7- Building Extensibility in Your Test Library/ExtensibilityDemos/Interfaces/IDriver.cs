namespace ExtensibilityDemos
{
    public interface IDriver : INavigationService, IBrowserService, ICookiesService, IElementFindService, IDialogService, IElementWaitService
    {
    }
}
