using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Zialinski_task.Enums;
using Zialinski_task.Listener;

namespace Zialinski_task.WrapperFactory
{
    internal class BrowserFactory : LogEventListener
    {
        private readonly IDictionary<Browser.Name, IWebDriver> _drivers = new Dictionary<Browser.Name, IWebDriver>();
        private static BrowserFactory _instance;
        private static IWebDriver _driver;

        private BrowserFactory() { }

        public static BrowserFactory GetInstance()
        {
            return _instance ?? (_instance = new BrowserFactory());
        }

        public static IWebDriver Driver
        {
            get => _driver;
            set => _driver = value;
        }

        public IWebDriver InitBrowser(Browser.Name browser)
        {
            switch (browser)
            {
                case Browser.Name.Firefox:
                    _driver = new FirefoxDriver();
                    InitializeEventFiringWebDriver();
                    if (!_drivers.Keys.Contains(Browser.Name.Firefox))
                        _drivers.Add(Browser.Name.Firefox, Driver);
                    return _driver;

                case Browser.Name.Chrome:
                    _driver = new ChromeDriver();
                    InitializeEventFiringWebDriver();
                    if (!_drivers.Keys.Contains(Browser.Name.Chrome))
                        _drivers.Add(Browser.Name.Chrome, Driver);
                    return _driver;
            }
            return _driver;
        }

        public void CloseAllDrivers()
        {
            foreach (var key in _drivers.Keys)
            {
                _drivers[key].Quit();
            }
            _drivers.Clear();
        }
    }
}
