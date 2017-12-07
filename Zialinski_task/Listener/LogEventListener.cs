using OpenQA.Selenium.Support.Events;
using Zialinski_task.WrapperFactory;

namespace Zialinski_task.Listener
{
    public class LogEventListener : EventListenerMethods
    {
        public void InitializeEventFiringWebDriver()
        {
            EventFiringWebDriver firingDriver = new EventFiringWebDriver(BrowserFactory.Driver);
            
            firingDriver.ExceptionThrown += FiringDriverExceptionThrown;
            firingDriver.ElementClicked += FiringDriverElementClicked;
            firingDriver.ElementClicking += FiringDriverElementClicking;
            firingDriver.FindElementCompleted += FiringDriverFindElementCompleted;
            firingDriver.FindingElement += FiringDriverFindingElement;
            firingDriver.ElementValueChanged += FiringDriverElementValueChanged;
            firingDriver.ElementValueChanging += FiringDriverElementValueChanging;
            firingDriver.Navigating += FiringDriverNavigating;
            firingDriver.Navigated += FiringDriverNavigated;

            BrowserFactory.Driver = firingDriver;
        }
    }
}
