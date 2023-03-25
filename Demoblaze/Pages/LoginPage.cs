using Demoblaze.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V108.Browser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demoblaze.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) { Driver = driver; }

        protected By btnNameOfUser = By.Id("nameofuser");
        protected By txtUserName = By.Id("loginusername");
        protected By txtPassword = By.Id("loginpassword");
        protected By optLogin = By.Id("login2");
        protected By btnLogin = By.XPath("//button[@onclick='logIn()']");
        protected By btnClose = By.XPath("//div[@class='modal-footer']/button[@class='btn btn-secondary']");
        public void enterUsername(string userName)
        {
            Helper.wait(Helper.tLow);
            sendKeys(txtUserName, userName);
        }
        public void enterPassword(string password) => sendKeys(txtPassword, password);


        public void clickLoginOption() => click(optLogin);

        public void clickLoginButton() => click(btnLogin);

        public void clickOnCloseLogin() => click(findElements(btnClose)[2]);

        public bool showLoginOption() => hasElement(optLogin);

        public bool validateMessageForLogin(string typeMessage)
        {
            Helper.wait(Helper.tLow);
            switch (typeMessage)
            {
                case "empty":
                    return (Driver.SwitchTo().Alert().Text.Contains("Please fill out Username and Password."));
                case "wPassword":
                    return (Driver.SwitchTo().Alert().Text.Contains("Wrong password."));
                case "wUser":
                    return (Driver.SwitchTo().Alert().Text.Contains("User does not exist."));
                default:
                    break;
            }
            return false;
        }
        public bool validateNameOfUSer(string name)
        {
            Helper.wait(Helper.tLow);
            return getText(findElement(btnNameOfUser)).Contains(name);
        }

        public string createBodyForLoginRest(string user, string password) => @"{""username"":""" + user + @""", ""password"": """ + password + @"""}";
    }
}
