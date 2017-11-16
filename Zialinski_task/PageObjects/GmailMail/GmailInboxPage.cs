using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task.Extensions;

namespace Zialinski_task.PageObjects.GmailMail
{
    public class GmailInboxPage
    {
        private WebDriverWait wait;
        private readonly string composeButtonName = "Compose Button";
        private readonly string messageSubjectBoxName = "Message Subject Box";
        private readonly string draftsLinkName = "Drafts Link";
        private string savedLableXPath = "//td[contains(@class, 'HE')]//span[contains(text(), 'Saved')]";

        [FindsBy(How = How.XPath, Using = "//div[@gh='cm' and @role='button']")]
        private IWebElement ComposeButton { get; set; }

        [FindsBy(How = How.Name, Using = "subjectbox")]
        private IWebElement MessageSubjectBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='navigation']//a[@href='https://mail.google.com/mail/#drafts']")]
        private IWebElement DraftsLink { get; set; }

        public void ClickComposeButton()
        {
            ComposeButton.ClickElement(composeButtonName);
        }

        public void InputMessageSubject(string messageSubject, IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(MessageSubjectBox));
            MessageSubjectBox.ClickElement(messageSubjectBoxName);
            MessageSubjectBox.InputText(messageSubject, messageSubjectBoxName);
        }

        public void WaitForSavedLable(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(savedLableXPath)));
        }

        public void GoToDrafts(IWebDriver driver)
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            DraftsLink.ClickElement(draftsLinkName);
        }
    }
}
