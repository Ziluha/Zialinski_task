using System;
using OpenQA.Selenium;

namespace Zialinski_task.ReportSettings
{
    public class GetScreenshot
    {
        public static string Capture(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot) driver;
            Screenshot screenshot = ts.GetScreenshot();

            string path = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string finalPath = path.Substring(0, path.LastIndexOf("bin"))+"ErrorScreenshots\\"+screenshotName+".png";
            string localPath = new Uri(finalPath).LocalPath;
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}
