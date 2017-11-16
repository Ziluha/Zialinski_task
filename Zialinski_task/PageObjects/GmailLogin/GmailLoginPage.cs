using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using Zialinski_task.Extensions;

namespace Zialinski_task.PageObjects.GmailLogin
{
    public class GmailLoginPage
    {
        private WebDriverWait wait;
        private readonly string passwordFieldName = "Password Field";
        private readonly string loginFieldName = "Login Field";
        private readonly string submitLoginButtonName = "Submit Login Button";
        private readonly string submitPasswordButtonName = "Submit Password Button";

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement SubmitLoginButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[jsname=B34EJ]")]
        private IWebElement LoginErrorLable { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField { get; set; }

        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement SubmitPasswordButton { get; set; }

        public void InputLogin(string login)
        {
            LoginField.ClickElement(loginFieldName);
            LoginField.InputText(login, loginFieldName);
        }

        public void SubmitLogin()
        {
            SubmitLoginButton.ClickElement(submitLoginButtonName);
        }

        public void InputPassword(string password, IWebDriver driver)
        {
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(PasswordField))
                .ClickElement(passwordFieldName);
            PasswordField.InputText(password, passwordFieldName);
        }

        public bool AreCredentialsWrong(IWebDriver driver)
        {
            try
            {
                if (LoginErrorLable.Displayed && LoginErrorLable.Text.Length != 0)
                    return true;
                return false;
            }
            catch (NoSuchElementException)
            {
                return false;
            }

        }

        public void SubmitPassword()
        {
            SubmitPasswordButton.ClickElement(submitPasswordButtonName);
        }
    }
}
