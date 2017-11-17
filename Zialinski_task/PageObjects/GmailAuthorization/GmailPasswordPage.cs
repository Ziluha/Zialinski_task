using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using Zialinski_task.Extensions;

namespace Zialinski_task.PageObjects.GmailLogin
{
    public class GmailPasswordPage
    {
        private WebDriverWait _wait;
        private const string PasswordFieldName = "Password Field";
        private const string SubmitPasswordButtonName = "Submit Password Button";

        [FindsBy(How = How.CssSelector, Using = "div[jsname=B34EJ]")]
        private IWebElement PasswordErrorLabel { get; set; }


        [FindsBy(How = How.CssSelector, Using = "div[id=password] div[jsname=YRMmle]")]
        private IWebElement InputPasswordLabel { get; set; }

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement PasswordField { get; set; }
        
        [FindsBy(How = How.Id, Using = "passwordNext")]
        private IWebElement SubmitPasswordButton { get; set; }

        public void InputPassword(string password, IWebDriver driver)
        {
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _wait.Until(ExpectedConditions.ElementToBeClickable(PasswordField))
                .ClickElement(PasswordFieldName);
            PasswordField.InputText(password, PasswordFieldName);
        }

        public void SubmitPassword()
        {
            SubmitPasswordButton.ClickElement(SubmitPasswordButtonName);
        }

        public bool IsPasswordErrorLabelPresented(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return _wait.Until(elemDisplayed => PasswordErrorLabel.Displayed);
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public bool IsLoginApplied(IWebDriver driver)
        {
            try
            {
                _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                return _wait.Until(elemDisplayed => InputPasswordLabel.Displayed);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
