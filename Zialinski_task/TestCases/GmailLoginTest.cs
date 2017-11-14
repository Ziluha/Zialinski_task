using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.DriverSettings;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailLoginTest : BaseTest
    {
        public GmailLoginTest() : base(Browser.Name.Chrome)
        {
        }

        [Test]
        public void LoginWithValidData()
        {
            test = extent.CreateTest("Login With Valid Data");
            Page.GmailLogin.InputLogin("test.task.zel@gmail.com");
            test.Log(test.Status, "Login inputted");
            Page.GmailLogin.SubmitLogin();
            test.Log(test.Status, "Login Submitted");
            Page.GmailLogin.InputPassword("Test1234Test", Driver);
            test.Log(test.Status, "Password inputted");
            Page.GmailLogin.SubmitPassword();
            test.Log(test.Status, "Password submitted");
        }

        [Test]
        public void LoginWithInvalidData()
        {
            test = extent.CreateTest("Login With Invalid Data");
            Page.GmailLogin.InputLogin("test.task.zel@gmmmail.com");
            test.Log(test.Status, "Login inputted");
            Page.GmailLogin.SubmitLogin();
            test.Log(test.Status, "Login Submitted");
            Page.GmailLogin.InputPassword("123123123", Driver);
            test.Log(test.Status, "Password inputted");
            Page.GmailLogin.SubmitPassword();
            test.Log(test.Status, "Password submitted");
        }
    }
}
