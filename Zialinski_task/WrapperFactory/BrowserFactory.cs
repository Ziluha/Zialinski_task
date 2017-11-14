using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Zialinski_task.Enums;

namespace Zialinski_task.WrapperFactory
{
    class BrowserFactory
    {
        private readonly IDictionary<Browser.Name, IWebDriver> drivers = new Dictionary<Browser.Name, IWebDriver>();
        private static BrowserFactory instance;
        private static IWebDriver driver;

        private BrowserFactory() { }

        public static BrowserFactory getInstance()
        {
            if (instance == null)
                instance = new BrowserFactory();
            return instance;
        }

        public static IWebDriver Driver
        {
            get => driver;
            set => driver = value;
        }

        public IWebDriver InitBrowser(Browser.Name browser)
        {
            switch (browser)
            {
                case Browser.Name.Firefox:
                    driver = new FirefoxDriver();
                    if (!drivers.Keys.Contains(Browser.Name.Firefox))
                        drivers.Add(Browser.Name.Firefox, Driver);
                    return driver;

                case Browser.Name.Chrome:
                    driver = new ChromeDriver();
                    if(!drivers.Keys.Contains(Browser.Name.Chrome))
                        drivers.Add(Browser.Name.Chrome, Driver);
                    return driver;
            }
            return driver;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in drivers.Keys)
            {
                drivers[key].Quit();
            }
            drivers.Clear();
        }
    }
}
