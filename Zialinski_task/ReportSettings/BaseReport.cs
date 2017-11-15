using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.ReportSettings
{
    [TestFixture]
    public class BaseReport
    {
        public ExtentReports extent;
        public ExtentTest test;
        public ExtentHtmlReporter htmlReporter;

        [OneTimeSetUp]
        public void StartReport()
        {
            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = path.Substring(0, path.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath;

            string reportPath = projectPath + "Reports\\Report.html";

            htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.LoadConfig(projectPath + "extent-config.xml");
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("By", "Zialinski Ivan");
        }

         [TearDown]
         public void GetResult()
         {
             var status = TestContext.CurrentContext.Result.Outcome.Status;
             var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
             var errorMessage = TestContext.CurrentContext.Result.Message;

             if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
             {
                 string screenshotPath = GetScreenshot.Capture(BrowserFactory.Driver, "ScreenShot");
                 test.Log(Status.Fail, stackTrace + errorMessage);
                 test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenshotPath));
             }
         }

        [OneTimeTearDown]
        public void StopReport()
        {
            extent.Flush();
            extent.RemoveTest(test);
        }
    }
}
