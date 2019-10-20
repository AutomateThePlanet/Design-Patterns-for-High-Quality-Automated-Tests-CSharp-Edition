namespace ExtensibilityDemos
{
    public class WaitStrategyFactory
    {
        public WaitToExistsStrategy Exists(int? timeoutInterval = null, int? sleepinterval = null)
        {
            return new WaitToExistsStrategy(timeoutInterval, sleepinterval);
        }

        public WaitToBeVisibleStrategy BeVisible(int? timeoutInterval = null, int? sleepinterval = null)
        {
            return new WaitToBeVisibleStrategy(timeoutInterval, sleepinterval);
        }

        public WaitToBeClickableStrategy BeClickable(int? timeoutInterval = null, int? sleepinterval = null)
        {
            return new WaitToBeClickableStrategy(timeoutInterval, sleepinterval);
        }
    }
}
