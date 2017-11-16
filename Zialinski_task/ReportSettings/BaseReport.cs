using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using Zialinski_task.Pathes;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.ReportSettings
{
    public class BaseReport
    {
        protected static ExtentReports extent;
        protected static ExtentTest test;
        private static ExtentHtmlReporter htmlReporter;
        
        public void StartReport(string testName)
        {
            string extentConfigName = "extent-config.xml";
            string binPath = ProjectPathes.GetBinPath();
            string actualPath = ProjectPathes.GetActualPath(binPath);
            string projectPath = ProjectPathes.GetLocalUri(actualPath);
            string reportPath = projectPath + "Reports\\Report"+testName+".html";

            htmlReporter = new ExtentHtmlReporter(reportPath);
            htmlReporter.LoadConfig(projectPath + extentConfigName);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);

            extent.AddSystemInfo("By", "Zialinski Ivan");
        }
        
         public void GetResult(string testName)
         {
             var status = TestContext.CurrentContext.Result.Outcome.Status;
             var stackTrace = "<pre>" + TestContext.CurrentContext.Result.StackTrace + "</pre>";
             var errorMessage = TestContext.CurrentContext.Result.Message;

             if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
             {
                 string screenshotPath = GetScreenshot.Capture(BrowserFactory.Driver, testName);
                 test.Log(Status.Fail, stackTrace + errorMessage);
                 test.Log(Status.Fail, "Snapshot below: " + test.AddScreenCaptureFromPath(screenshotPath));
             }
         }
        
        public void StopReport()
        {
            extent.Flush();
            extent.RemoveTest(test);
        }
    }
}
