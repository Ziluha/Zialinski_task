using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using Zialinski_task.Extensions;

namespace Zialinski_task.PageObjects.GmailLogin
{
    public class GmailLoginPage
    {
        private WebDriverWait _wait;
        private const string LoginFieldName = "Login Field";
        private const string SubmitLoginButtonName = "Submit Login Button";

        [FindsBy(How = How.Id, Using = "identifierId")]
        private IWebElement LoginField { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[jsname=B34EJ]")]
        private IWebElement LoginErrorLabel { get; set; }

        [FindsBy(How = How.Id, Using = "identifierNext")]
        private IWebElement SubmitLoginButton { get; set; }


        public void InputLogin(string login)
        {
            LoginField.ClickElement(LoginFieldName);
            LoginField.InputText(login, LoginFieldName);
        }

        public void SubmitLogin()
        {
            SubmitLoginButton.ClickElement(SubmitLoginButtonName);
        }
        
        public bool IsLoginErrorLabelPresented(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return _wait.Until(elemDisplayed => LoginErrorLabel.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
