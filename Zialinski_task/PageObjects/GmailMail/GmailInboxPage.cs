using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task.Extensions;

namespace Zialinski_task.PageObjects.GmailMail
{
    public class GmailInboxPage
    {
        private WebDriverWait _wait;
        private const string ComposeButtonName = "Compose Button";
        private const string MessageSubjectBoxName = "Message Subject Box";
        private const string DraftsLinkName = "Drafts Link";
        private const string SavedLableXPath = "//td[contains(@class, 'HE')]//span[contains(text(), 'Saved')]";

        [FindsBy(How = How.XPath, Using = "//div[@gh='cm' and @role='button']")]
        private IWebElement ComposeButton { get; set; }

        [FindsBy(How = How.Name, Using = "subjectbox")]
        private IWebElement MessageSubjectBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='navigation']//a[@href='https://mail.google.com/mail/#drafts']")]
        private IWebElement DraftsLink { get; set; }

        public void ClickComposeButton()
        {
            ComposeButton.ClickElement(ComposeButtonName);
        }

        public void InputMessageSubject(string messageSubject)
        {
            MessageSubjectBox.ClickElement(MessageSubjectBoxName);
            MessageSubjectBox.InputText(messageSubject, MessageSubjectBoxName);
        }

        public bool IsLoginSucceed(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return _wait.Until(elemDisplayed => ComposeButton.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsSavedLabelDisplayed(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                _wait.Until(ExpectedConditions.ElementExists(By.XPath(SavedLableXPath)));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public void GoToDrafts()
        {
            DraftsLink.ClickElement(DraftsLinkName);
        }
    }
}
