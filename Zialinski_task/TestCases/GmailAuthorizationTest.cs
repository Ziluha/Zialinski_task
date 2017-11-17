using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailAuthorizationTest : BaseTest
    {
        private const string TestName = "GmailLoginTest";
        public GmailAuthorizationTest() : base(Browser.Name.Firefox, TestName) { }

        [Test]
        public void AuthorizationWithValidData()
        {
            Test = Extent.CreateTest("Authorization With Valid Data");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            Test.Log(Status.Pass, "Login is submitted");
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Test.Log(Status.Pass, "Password is inputted");
            Page.GmailPassword.SubmitPassword();
            Test.Log(Status.Pass, "Password is submitted");
            Assert.True(Page.GmailInbox.IsLoginSucceed(Driver), "User was not logged in");
            Test.Log(Status.Pass, "Login is succeed");
        }

        [Test]
        public void AuthorizationWithInvalidLogin()
        {
            Test = Extent.CreateTest("Authorization With Invalid Login");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            Test.Log(Status.Pass, "Login is submitted");
            Assert.True(Page.GmailLogin.IsLoginErrorLabelPresented(Driver), "Login Error Lable is not presented");
            Test.Log(Status.Pass, "Login is invalid");
        }

        [Test]
        public void AuthorizationWithInvalidPassword()
        {
            Test = Extent.CreateTest("Authorization With Invalid Password");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            Test.Log(Status.Pass, "Login is submitted");
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"], Driver);
            Test.Log(Status.Pass, "Password is inputted");
            Page.GmailPassword.SubmitPassword();
            Test.Log(Status.Pass, "Password is submitted");
            Assert.True(Page.GmailPassword.IsPasswordErrorLabelPresented(Driver), "Password Error Lable is not presented");
            Test.Log(Status.Pass, "Password is invalid");
        }
    }
}
