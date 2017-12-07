﻿using System.Configuration;
using Meyn.TestLink;
using NUnit.Framework;
using Taps;
using Zialinski_task.Enums;
using Zialinski_task.PageObjects;
using Zialinski_task.TestSettings;

namespace Zialinski_task.TestCases
{
    [TestFixture]
    public class GmailDraftTest : BaseTest
    {
        private const string TestName = "GmailDraftTest";
        public GmailDraftTest() : base(Browser.Name.Chrome, TestName) { }

        [SetUp]
        public void SetUpAuth()
        {
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Page.GmailLogin.SubmitLogin();
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Page.GmailPassword.SubmitPassword();
        }
        
        [Test]
        public void AddMessageToDrafts()
        {
            string testCaseName = "Add Message To Drafts";
            Test = Extent.CreateTest(testCaseName);
            Page.GmailInbox.ClickComposeButton();
            Page.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            Assert.True(Page.GmailInbox.IsSavedLabelDisplayed(Driver), "Saved Lable is not presented");
            Page.GmailInbox.GoToDrafts();
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(Driver), "Draft Page is not opened");
            Assert.True(Page.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");
            TAP.Pass(testCaseName);
            Test.Pass("Message added to drafts");
        }

        [Test]
        public void DeleteMessageFromDrafts()
        {
            string testCaseName = "Delete Message From Drafts";
            int draftNumber = 3;
            Test = Extent.CreateTest(testCaseName);
            Page.GmailInbox.GoToDrafts();
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(Driver),"Draft Page is not opened");
            int countOfDraftsAtStart = Page.GmailDrafts.GetCountOfDrafts();
            Page.GmailDrafts.ChooseDraft(draftNumber);
            Page.GmailDrafts.ClickDiscardDraftsButton();
            Assert.AreEqual(countOfDraftsAtStart-1, Page.GmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");
            TAP.Pass(testCaseName);
            Test.Pass("Message deleted from drafts");
        }
    }
}
