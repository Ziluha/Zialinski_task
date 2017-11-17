using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    class GmailFailCheckTest : BaseTest
    {
        private const string TestName = "GmailFailCheckTest";
        public GmailFailCheckTest() : base(Browser.Name.Chrome, TestName) { }

        [NUnit.Framework.Test]
        public void FailReportCheckTest()
        {
            Test = Extent.CreateTest(TestName);
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            Test.Log(Status.Pass, "Login is submitted");
            Assert.True(Page.GmailPassword.IsLoginApplied(Driver),"Password page is not opened");
            Test.Log(Status.Pass, "Password page is opened");
        }
    }
}
