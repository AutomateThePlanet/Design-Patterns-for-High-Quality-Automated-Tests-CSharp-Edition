using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace ApiUsabilityDemos
{
    public class LoggingSingletonDriver : DriverDecorator
    {
        private static LoggingSingletonDriver _instance;

        public static LoggingSingletonDriver Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new LoggingSingletonDriver(new WebDriver());
                }

                return _instance;
            }
        }

        private LoggingSingletonDriver(Driver driver)
            : base(driver)
        {
        }

        public override void Start(Browser browser)
        {
            Console.WriteLine($"Start browser = {Enum.GetName(typeof(Browser), browser)}");
            Driver?.Start(browser);
        }

        public override void Quit()
        {
            Console.WriteLine("Close browser");
            Driver?.Quit();
        }

        public override void GoToUrl(string url)
        {
            Console.WriteLine($"Go to URL = {url}");
            Driver?.GoToUrl(url);
        }

        public override Element FindElement(By locator)
        {
            Console.WriteLine("Find Element");
            return Driver?.FindElement(locator);
        }

        public override List<Element> FindElements(By locator)
        {
            Console.WriteLine("Find elements");
            return Driver?.FindElements(locator);
        }
    }
}
