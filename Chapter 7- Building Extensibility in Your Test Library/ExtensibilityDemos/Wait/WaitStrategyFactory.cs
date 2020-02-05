namespace ExtensibilityDemos
{
    public class WaitStrategyFactory
    {
        public WaitToExistsStrategy Exists(int? timeoutInterval = null, int? sleepInterval = null)
        {
            return new WaitToExistsStrategy(timeoutInterval, sleepInterval);
        }

        public WaitToBeVisibleStrategy BeVisible(int? timeoutInterval = null, int? sleepInterval = null)
        {
            return new WaitToBeVisibleStrategy(timeoutInterval, sleepInterval);
        }

        public WaitToBeClickableStrategy BeClickable(int? timeoutInterval = null, int? sleepInterval = null)
        {
            return new WaitToBeClickableStrategy(timeoutInterval, sleepInterval);
        }
    }
}
