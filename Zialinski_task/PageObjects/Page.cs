using OpenQA.Selenium.Support.PageObjects;
using Zialinski_task.PageObjects.GmailLogin;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static GmailLoginPage GmailLogin => GetPage<GmailLoginPage>();
    }
}
