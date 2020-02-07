namespace ExtensibilityDemos
{
    public class WaitStrategyFactory
    {
        public ToExistsWaitStrategy Exists(int? timeoutInterval = null, int? sleepInterval = null)
        {
            return new ToExistsWaitStrategy(timeoutInterval, sleepInterval);
        }

        public ToBeVisibleWaitStrategy BeVisible(int? timeoutInterval = null, int? sleepInterval = null)
        {
            return new ToBeVisibleWaitStrategy(timeoutInterval, sleepInterval);
        }

        public ToBeClickableWaitStrategy BeClickable(int? timeoutInterval = null, int? sleepInterval = null)
        {
            return new ToBeClickableWaitStrategy(timeoutInterval, sleepInterval);
        }
    }
}
