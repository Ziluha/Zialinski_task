using System.Configuration;
using NUnit.Framework;
using Taps;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.ReportSettings;
using Zialinski_task.TapReporting;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailFailCheck : BaseTest
    {
        private const string TestName = "GmailFailCheckTest";
        public GmailFailCheck() : base(Browser.Name.Chrome, TestName) { }

        [Test]
        public void FailReportCheckTest()
        {
            TestCaseName = "FailReportCheckTest";
            CreateTapReport.SetTAPReportName(TestCaseName);
            Test = Extent.CreateTest(TestCaseName);
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Assert.True(Page.GmailPassword.IsLoginApplied(Driver), "Password page is not opened");
            TAP.Pass(TestCaseName);
            Test.Pass("Fail check is succeed");
        }
    }
}
