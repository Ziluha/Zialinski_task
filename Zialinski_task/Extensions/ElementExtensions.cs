using OpenQA.Selenium;

namespace Zialinski_task.Extensions
{
    public static class ElementExtensions
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().Name);

        public static void ClickElement(this IWebElement element, string elementName)
        {
            element.Click();
            Log.Info(elementName + " is clicked");
        }

        public static void InputText(this IWebElement element, string text, string elementName)
        {
            element.SendKeys(text);
            Log.Info(text + " is inputed in "+elementName);
        }
    }
}
