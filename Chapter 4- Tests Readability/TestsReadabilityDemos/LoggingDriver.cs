using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace TestsReadabilityDemos
{
    public class LoggingDriver : DriverDecorator
    {
        public LoggingDriver(Driver driver)
        : base(driver)
        {
        }

        public override void Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            driver?.Start(browser);
        }

        public override void Quit()
        {
            Console.WriteLine("Close browser");
            driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine("Find element");
            return driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            Console.WriteLine("Find elements");
            return driver?.FindElements(locator);
        }
    }
}
