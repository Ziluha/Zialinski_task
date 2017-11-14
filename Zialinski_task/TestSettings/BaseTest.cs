using NUnit.Framework;
using OpenQA.Selenium;
using System.Configuration;
using Zialinski_task.DriverSettings;
using Zialinski_task.Enums;
using Zialinski_task.ReportSettings;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.TestSettings
{
    [TestFixture]
    public class BaseTest : BaseReport
    {
        protected IWebDriver Driver { get; set; }
        private Browser.Name browserName;
        private BrowserFactory browserFactory;

        public BaseTest(Browser.Name _browserName)
        {
            browserName = _browserName;
            browserFactory = BrowserFactory.getInstance();
        }

        public void ChooseDriverInstance(Browser.Name _browserName)
        {
            if (_browserName == Browser.Name.Chrome)
                Driver = browserFactory.InitBrowser(Browser.Name.Chrome);
            else if (_browserName == Browser.Name.Firefox)
                Driver = browserFactory.InitBrowser(Browser.Name.Firefox);
        }

        [SetUp]
        public void Init()
        {
            ChooseDriverInstance(browserName);
            DriverConfiguration.LoadApp(Driver, ConfigurationManager.AppSettings["GmailURL"]);
        }

        [TearDown]
        public void EndTest()
        {
            browserFactory.CloseAllDrivers();
        }
    }
}
