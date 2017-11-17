using System.IO;
using OpenQA.Selenium;
using Zialinski_task.Pathes;

namespace Zialinski_task.ReportSettings
{
    public class GetScreenshot
    {

        public static string Capture(IWebDriver driver, string screenshotName)
        {
            ITakesScreenshot ts = (ITakesScreenshot) driver;
            Screenshot screenshot = ts.GetScreenshot();
            int i = 1;
            string binPath = ProjectPathes.GetBinPath();
            string screenPath = ProjectPathes.GetActualPath(binPath) + "ErrorScreenshots/"+screenshotName+"{0}.png";
            string localPath = ProjectPathes.GetLocalUri(screenPath);
            while (File.Exists(localPath))
            {
                string finalPath = string.Format(screenPath, i);
                localPath = ProjectPathes.GetLocalUri(finalPath);
                ++i;
            }
            screenshot.SaveAsFile(localPath, ScreenshotImageFormat.Png);
            return localPath;
        }
    }
}
