using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task.Extensions;

namespace Zialinski_task.PageObjects.GmailMail
{
    public class GmailDraftsPage
    {
        private WebDriverWait wait;
        private readonly string draftCheckBoxName = "Draft Checkbox";
        private readonly string discardDraftsButtonName = "Discard Drafts Button";

        [FindsBy(How = How.XPath, Using = "//div[@role='main']//span[@class='bog']")]
        private IList<IWebElement> DraftSubjectsList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='main']//div[@role='checkbox']")]
        private IList<IWebElement> DraftCheckboxesList { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='button' and @act='16']/div")]
        private IWebElement DiscardDraftsButton { get; set; }

        public bool IsDraftAdded(string messageSubject)
        {
            if (DraftSubjectsList != null && DraftSubjectsList.First().Text == messageSubject)
                return true;
            return false;
        }

        public void ChooseFirstDraft(int draftNumber, IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(DraftCheckboxesList.ElementAt(draftNumber)));
            DraftCheckboxesList.ElementAt(draftNumber).ClickElement(draftCheckBoxName);
        }

        public void ClickDiscardDraftsButton(IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(DiscardDraftsButton));
            DiscardDraftsButton.ClickElement(discardDraftsButtonName);
        }
    }
}
