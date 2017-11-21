using AventStack.ExtentReports;
using OpenQA.Selenium.Support.Events;
using Zialinski_task.ReportSettings;

namespace Zialinski_task.Listener
{
    public class EventListenerMethods : BaseReport
    {
        private static readonly log4net.ILog Log =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().Name);

        public static void FiringDriverNavigating(object sender, WebDriverNavigationEventArgs e)
        {
            string logMessage = "Try to open page: "+ e.Url;
            Log.Info(logMessage);
            Test?.Log(Status.Debug, logMessage);
        }

        public static void FiringDriverNavigated(object sender, WebDriverNavigationEventArgs e)
        {
            string logMessage = "Page is opened: " + e.Url;
            Log.Info(logMessage);
            Test?.Log(Status.Info, logMessage);
        }


        public static void FiringDriverExceptionThrown(object sender, WebDriverExceptionEventArgs e)
        {
            string logMessage = e.ThrownException.Message;
            Log.Info(logMessage);
            Test?.Log(Status.Info, logMessage);
        }

        public static void FiringDriverElementClicked(object sender, WebElementEventArgs e)
        {
            string logMessage = "Element is clicked";
            Log.Info(logMessage);
            Test?.Log(Status.Info, logMessage);
        }

        public static void FiringDriverElementClicking(object sender, WebElementEventArgs e)
        {
            string logMessage = "Try to click element " + e.Element.Text;
            Log.Info(logMessage);
            Test?.Log(Status.Debug, logMessage);
        }

        public static void FiringDriverFindElementCompleted(object sender, FindElementEventArgs e)
        {
            string logMessage = "Element is founded " + e.FindMethod;
            Log.Info(logMessage);
            Test?.Log(Status.Info, logMessage);
        }

        public static void FiringDriverFindingElement(object sender, FindElementEventArgs e)
        {
            string logMessage = "Finding element " + e.FindMethod;
            Log.Info(logMessage);
            Test?.Log(Status.Debug, logMessage);
        }

        public static void FiringDriverElementValueChanged(object sender, WebElementEventArgs e)
        {
            string logMessage = "Element value after changing: " + e.Element.GetAttribute("value");
            Log.Info(logMessage);
            Test?.Log(Status.Debug, logMessage);
        }

        public static void FiringDriverElementValueChanging(object sender, WebElementEventArgs e)
        {
            string logMessage = "Element value before changing: " + e.Element.GetAttribute("value");
            Log.Info(logMessage);
            Test?.Log(Status.Debug, logMessage);
        }
    }
}
