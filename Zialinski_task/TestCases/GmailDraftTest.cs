using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using NUnit.Framework;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.PageObjects.GmailMail;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailDraftTest : BaseTest
    {
        private static readonly string _testName = "GmailDraftTest";
        public GmailDraftTest() : base(Browser.Name.Chrome, _testName) { }

        [SetUp]
        public void SetUpAuth()
        {
            test = extent.CreateTest("Set Up Login With Valid Data");
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
        public void AddMessageToDrafts()
        {
            test = extent.CreateTest("Add Message To Drafts");
            Page.GmailInbox.ClickComposeButton();
            test.Log(Status.Pass, "Compose Button is clicked");
            Page.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            test.Log(Status.Pass, "Message Subject is inputted");
            Assert.True(Page.GmailInbox.WaitForSavedLable(Driver), "Saved Lable is not presented");
            test.Log(Status.Pass, "Saved Lable is presented");
            Page.GmailInbox.GoToDrafts();
            test.Log(Status.Pass, "Drafts Link is clicked");
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(Driver), "Draft Page is not opened");
            test.Log(Status.Pass, "Draft Page is opened");
            Assert.True(Page.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");
            test.Log(Status.Pass, "Message was added in drafts");
        }

        [Test]
        public void DeleteMessageFromDrafts()
        {
            int draftNumber = 3;
            test = extent.CreateTest("Delete Message From Drafts");
            Page.GmailInbox.GoToDrafts();
            test.Log(Status.Pass, "Drafts Link is clicked");
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(Driver),"Draft Page is not opened");
            test.Log(Status.Pass, "Draft Page is opened");
            Page.GmailDrafts.ChooseFirstDraft(draftNumber);
            test.Log(Status.Pass, "First Draft is choosen");
            Page.GmailDrafts.ClickDiscardDraftsButton();
            test.Log(Status.Pass, "Draft is discarded");
        }
    }
}
