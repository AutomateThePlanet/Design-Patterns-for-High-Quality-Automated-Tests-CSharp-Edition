namespace ExtensibilityDemos
{
    public interface IElementWaitService
    {
        void Wait(Element element, WaitStrategy waitStrategy);
    }
}