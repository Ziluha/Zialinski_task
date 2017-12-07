using System.Configuration;
using Meyn.TestLink;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
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
            Test = Extent.CreateTest(TestName);
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Page.GmailLogin.SubmitLogin();
            TAP.Core.TAP.Fail("Failed");
            Assert.True(Page.GmailPassword.IsLoginApplied(Driver), "Password page is not opened");
            Test.Pass("Fail check is succeed");
        }
    }
}
