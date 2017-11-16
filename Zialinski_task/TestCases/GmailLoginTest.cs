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
        private static readonly string _testName = "GmailLoginTest";
        public GmailLoginTest() : base(Browser.Name.Chrome, _testName) { }

        [Test]
        public void LoginWithValidData()
        {
            test = extent.CreateTest("Login With Valid Data");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            test.Log(Status.Pass, "Login is submitted");
            Page.GmailLogin.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            test.Log(Status.Pass, "Password is inputted");
            Page.GmailLogin.SubmitPassword();
            test.Log(Status.Pass, "Password is submitted");
        }

        [Test]
        public void LoginWithInvalidData()
        {
            test = extent.CreateTest("Login With Invalid Data");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            if (Page.GmailLogin.AreCredentialsWrong(Driver))
                test.Log(Status.Pass, "Login is wrong");
            else
            {
                test.Log(Status.Pass, "Login is submitted");
                Page.GmailLogin.InputPassword(ConfigurationManager.AppSettings["InvalidPassword"],Driver);
                test.Log(Status.Pass, "Password is inputted");
                Page.GmailLogin.SubmitPassword();
                if (Page.GmailLogin.AreCredentialsWrong(Driver))
                    test.Log(Status.Pass, "Password is wrong");
                else
                {
                    test.Log(Status.Pass, "Password is submitted");
                }
            }
        }
    }
}
