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
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Page.GmailPassword.SubmitPassword();
            Assert.True(Page.GmailInbox.IsLoginSucceed(Driver), "User was not logged in");
            Test.Pass("User successfully authorized");
        }

        [Test]
        public void AuthorizationWithInvalidLogin()
        {
            Test = Extent.CreateTest("Authorization With Invalid Login");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["InvalidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Assert.True(Page.GmailLogin.IsLoginErrorLabelPresented(Driver), "Login Error Lable is not presented");
            Test.Pass("User is not authorized with invalid login");
        }

        [Test]
        public void AuthorizationWithInvalidPassword()
        {
            Test = Extent.CreateTest("Authorization With Invalid Password");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"], Driver);
            Page.GmailPassword.SubmitPassword();
            Assert.True(Page.GmailPassword.IsPasswordErrorLabelPresented(Driver), 
                "Password Error Lable is not presented");
            Test.Pass("User is not authorized with invalid password");
        }
    }
}
