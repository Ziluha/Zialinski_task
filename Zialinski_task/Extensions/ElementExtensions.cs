using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Zialinski_task.ReportSettings;

namespace Zialinski_task.Extensions
{
    public static class ElementExtensions
    {
        private static readonly log4net.ILog log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().Name);

        public static void ClickElement(this IWebElement element, string elementName)
        {
            element.Click();
            log.Info(elementName + " is clicked");
        }

        public static void InputText(this IWebElement element, string text, string elementName)
        {
            element.SendKeys(text);
            log.Info(text + " is inputed in "+elementName);
        }
    }
}
