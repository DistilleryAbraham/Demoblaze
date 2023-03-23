using Demoblaze.Helpers;
using Demoblaze.Hooks;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Demoblaze.Pages
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) { Driver = driver; }

        protected By btnSignUp = By.Id("signin2");
        protected By txtUserName = By.Id("sign-username");
        protected By txtPassword = By.Id("sign-password");
        protected By btnSignUpEnter = By.XPath("//button[@onclick='register()']");
        protected By btnCloseSignUp = By.XPath("//class[@btn btn-secondary']");

        public bool validateThemainPage(string url)
        {
            if (Driver.Url.Equals(url))
            {
                return true;
            }
            return false;
        }

        public void clickSignUp() => click(btnSignUp);

        public void enterUsername(string userName)
        {
            Helper.wait(Helper.tLow);
            sendKeys(txtUserName, userName + Helper.generateLetter());
        }
        public void enterSameUsername(string userName)
        {
            Helper.wait(Helper.tLow);
            sendKeys(txtUserName, userName);
        }
        public void enterPassword(string password) => sendKeys(txtPassword, password + Helper.generateLetter());
        public void enterSamePassword(string password) => sendKeys(txtPassword, password);
        public void clickSignUpEnter() => click(btnSignUpEnter);
        public void clickSignUpClose() => click(btnCloseSignUp);

        public bool hasSignUMessage(string succes)
        {
            Helper.wait(Helper.tLow);
            string message = Driver.SwitchTo().Alert().Text;
            bool successMessage = false;
            if (succes.Equals("yes"))
            {
                if (message.Contains("Sign up successful."))
                {
                    successMessage = true;
                }
            }
            else if (succes.Equals("empty"))
            {
                if (message.Contains("Please fill out Username and Password."))
                {
                    successMessage = true;
                }
            }
            else
            {
                if (message.Contains("This user already exist."))
                {
                    successMessage = true;
                }
            }
            Driver.SwitchTo().Alert().Accept();
            return successMessage;
        }
    }
}
