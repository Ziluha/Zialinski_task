using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using Zialinski_task.Pathes;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.ReportSettings
{
    public class BaseReport
    {
        protected static ExtentReports Extent;
        protected static ExtentTest Test;
        private static ExtentHtmlReporter _htmlReporter;
        
        public void StartReport(string testName)
        {
            string extentConfigName = "extent-config.xml";
            string binPath = ProjectPathes.GetBinPath();
            string actualPath = ProjectPathes.GetActualPath(binPath);
            string projectPath = ProjectPathes.GetLocalUri(actualPath);
            string reportPath = projectPath + "Reports\\Report"+testName+".html";

            _htmlReporter = new ExtentHtmlReporter(reportPath);
            _htmlReporter.LoadConfig(projectPath + extentConfigName);
            Extent = new ExtentReports();
            Extent.AttachReporter(_htmlReporter);

            Extent.AddSystemInfo("By", "Zialinski Ivan");
        }
        
         public void GetResult(string testName)
         {
             var status = TestContext.CurrentContext.Result.Outcome.Status;
             var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
             var errorMessage = TestContext.CurrentContext.Result.Message;

             if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
             {
                 string screenshotPath = GetScreenshot.Capture(BrowserFactory.Driver, testName);
                 Test.Log(Status.Fail, stackTrace + errorMessage);
                 Test.Log(Status.Fail, "Snapshot below: " + Test.AddScreenCaptureFromPath(screenshotPath));
            }
             Test = null;
         }
        
        public void StopReport()
        {
            Extent.Flush();
            Extent.RemoveTest(Test);
        }
    }
}
