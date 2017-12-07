using System.Configuration;
using Meyn.TestLink;
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
    public class GmailAuthorizationTest : BaseTest
    {
        private const string TestName = "GmailLoginTest";
        public GmailAuthorizationTest() : base(Browser.Name.Chrome, TestName) { }

        [Test]
        public void AuthorizationWithValidData()
        {
            TestCaseName = "AuthorizationWithValidData";
            Test = Extent.CreateTest(TestCaseName);
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Page.GmailPassword.SubmitPassword();
            Assert.True(Page.GmailInbox.IsLoginSucceed(Driver), "User was not logged in");
            TAP.Pass(TestCaseName);
            Test.Pass("User successfully authorized");
        }

        [Test]
        public void AuthorizationWithInvalidLogin()
        {
            TestCaseName = "AuthorizationWithInvalidLogin";
            Test = Extent.CreateTest(TestCaseName);
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Assert.True(Page.GmailLogin.IsLoginErrorLabelPresented(Driver), "Login Error Lable is not presented");
            TAP.Pass(TestCaseName);
            Test.Pass("User is not authorized with invalid login");
        }

        [Test]
        public void AuthorizationWithInvalidPassword()
        {
            TestCaseName = "AuthorizationWithInvalidPassword";
            Test = Extent.CreateTest(TestCaseName);
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"], Driver);
            Page.GmailPassword.SubmitPassword();
            Assert.True(Page.GmailPassword.IsPasswordErrorLabelPresented(Driver), 
                "Password Error Lable is not presented");
            TAP.Pass(TestCaseName);
            Test.Pass("User is not authorized with invalid password");
        }
    }
}
