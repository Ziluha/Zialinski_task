using System.Configuration;
using AventStack.ExtentReports;
using NUnit.Framework;
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
            Test = Extent.CreateTest("Set Up Login With Valid Data");
            Page.GmailLogin.InputLogin(ConfigurationManager.AppSettings["ValidLogin"]);
            Test.Log(Status.Pass, "Login is inputted");
            Page.GmailLogin.SubmitLogin();
            Test.Log(Status.Pass, "Login is submitted");
            Page.GmailPassword.InputPassword(ConfigurationManager.AppSettings["ValidPassword"], Driver);
            Test.Log(Status.Pass, "Password is inputted");
            Page.GmailPassword.SubmitPassword();
            Test.Log(Status.Pass, "Password is submitted");
        }
        
        [Test]
        public void AddMessageToDrafts()
        {
            Test = Extent.CreateTest("Add Message To Drafts");
            Page.GmailInbox.ClickComposeButton();
            Test.Log(Status.Pass, "Compose Button is clicked");
            Page.GmailInbox.InputMessageSubject(ConfigurationManager.AppSettings["TextSample"]);
            Test.Log(Status.Pass, "Message Subject is inputted");
            Assert.True(Page.GmailInbox.IsSavedLabelDisplayed(Driver), "Saved Lable is not presented");
            Test.Log(Status.Pass, "Saved Lable is presented");
            Page.GmailInbox.GoToDrafts();
            Test.Log(Status.Pass, "Drafts Link is clicked");
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(Driver), "Draft Page is not opened");
            Test.Log(Status.Pass, "Draft Page is opened");
            Assert.True(Page.GmailDrafts.IsDraftAdded(ConfigurationManager.AppSettings["TextSample"]),
                "No message with this subject in drafts");
            Test.Log(Status.Pass, "Message was added in drafts");
        }

        [Test]
        public void DeleteMessageFromDrafts()
        {
            int draftNumber = 3;
            Test = Extent.CreateTest("Delete Message From Drafts");
            Page.GmailInbox.GoToDrafts();
            Test.Log(Status.Pass, "Drafts Link is clicked");
            Assert.True(Page.GmailDrafts.IsDraftPageOpened(Driver),"Draft Page is not opened");
            Test.Log(Status.Pass, "Draft Page is opened");
            int countOfDraftsAtStart = Page.GmailDrafts.GetCountOfDrafts();
            Test.Log(Status.Pass, "Count of Drafts is getted");
            Page.GmailDrafts.ChooseFirstDraft(draftNumber);
            Test.Log(Status.Pass, "First Draft is choosen");
            Page.GmailDrafts.ClickDiscardDraftsButton();
            Test.Log(Status.Pass, "Discard button is clicked");
            Assert.AreEqual(countOfDraftsAtStart-1, Page.GmailDrafts.GetCountOfDrafts(),
                "Count of drafts at start and afted discarding doesn't match");
            Test.Log(Status.Pass, "Draft was discarded");
        }
    }
}
