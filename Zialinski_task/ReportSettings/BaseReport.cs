using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

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

        [OneTimeTearDown]
        public void StopReport()
        {
            extent.Flush();
            extent.RemoveTest(test);
        }
    }
}
