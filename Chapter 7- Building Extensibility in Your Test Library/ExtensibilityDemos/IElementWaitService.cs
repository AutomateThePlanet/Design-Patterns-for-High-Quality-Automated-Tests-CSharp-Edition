namespace ExtensibilityDemos
{
    public interface IElementWaitService
    {
        void Wait<TWaitStrategy, TElement>(TElement element, TWaitStrategy waitStrategy)
            where TWaitStrategy : WaitStrategy
            where TElement : Element;
    }
}
