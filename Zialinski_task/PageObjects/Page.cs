using System;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task.PageObjects.GmailAuthorization;
using Zialinski_task.PageObjects.GmailMail;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            BrowserFactory.Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static GmailLoginPage GmailLogin => GetPage<GmailLoginPage>();
        public static GmailPasswordPage GmailPassword => GetPage<GmailPasswordPage>();
        public static GmailInboxPage GmailInbox => GetPage<GmailInboxPage>();
        public static GmailDraftsPage GmailDrafts => GetPage<GmailDraftsPage>();
    }
}
