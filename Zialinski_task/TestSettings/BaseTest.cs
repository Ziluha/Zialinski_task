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
        private readonly Browser.Name _browserName;
        private readonly BrowserFactory _browserFactory;
        private readonly string _testName;

        public BaseTest(Browser.Name browserName, string testName)
        {
            _browserName = browserName;
            _browserFactory = BrowserFactory.GetInstance();
            _testName = testName;
        }

        public void ChooseDriverInstance(Browser.Name browserName)
        {
            if (browserName == Browser.Name.Chrome)
                Driver = _browserFactory.InitBrowser(Browser.Name.Chrome);
            else if (browserName == Browser.Name.Firefox)
                Driver = _browserFactory.InitBrowser(Browser.Name.Firefox);
        }

        [OneTimeSetUp]
        public void InitReport()
        {
            StartReport(_testName);
        }

        [SetUp]
        public void Init()
        {
            ChooseDriverInstance(_browserName);
            DriverConfiguration.LoadApp(Driver, ConfigurationManager.AppSettings["GmailURL"]);
        }

        [TearDown]
        public void EndTest()
        {
            GetResult(_testName);
            _browserFactory.CloseAllDrivers();
        }

        [OneTimeTearDown]
        public void EndReport()
        {
            StopReport();
        }
    }
}
