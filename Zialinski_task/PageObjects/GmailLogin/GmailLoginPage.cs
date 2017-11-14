using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
namespace Zialinski_task.PageObjects.GmailLogin
{
    public class GmailLoginPage
    {
        private WebDriverWait wait;

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement SubmitLoginButton { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement SubmitPasswordButton { get; set; }

        public void InputLogin(string login)
        {
            LoginField.Click();
            LoginField.SendKeys(login);
        }

        public void SubmitLogin()
        {
            SubmitLoginButton.Click();
        }

        public void InputPassword(string password, IWebDriver driverForWait)
        {
            wait = new WebDriverWait(driverForWait, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(PasswordField));
            PasswordField.Click();
            PasswordField.SendKeys(password);
        }

        public void SubmitPassword()
        {
            SubmitPasswordButton.Click();
        }
    }
}
