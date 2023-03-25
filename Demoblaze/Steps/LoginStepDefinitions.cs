using Demoblaze.Helpers;
using Demoblaze.Hooks;
using Demoblaze.Pages;
using Demoblaze.Request;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Demoblaze.Steps
{
    [Binding]
    public class LoginStepDefinitions : InitialHooks
    {
        LoginPage loginPage = new LoginPage(Driver);

        [When(@"Click on Login option")]
        public void WhenClickOnLoginOption()
        {
            loginPage.clickLoginOption();
        }

        [When(@"Enter username to login (.*)")]
        public void WhenEnterUsernameToLogin(string userName)
        {
            loginPage.enterUsername(userName);

        }

        [When(@"Enter password to login (.*)")]
        public void WhenEnterPasswordToLogin(string password)
        {
            loginPage.enterPassword(password);
        }

        [When(@"Click on Login button")]
        public void WhenClickOnLoginButton()
        {
            loginPage.clickLoginButton();
        }

        [Then(@"Show the userName logged (.*)")]
        public void ThenShowTheUserNameLogged(string name)
        {
            Assert.IsTrue(loginPage.validateNameOfUSer(name));
        }

        [Then(@"Show the message to login (.*)")]
        public void ThenShowTheMessageToLogin(string typeMessage)
        {
            Assert.IsTrue(loginPage.validateMessageForLogin(typeMessage));
        }

        [When(@"Click on cancel login button")]
        public void WhenClickOnCancelLoginButton()
        {
            loginPage.clickOnCloseLogin();
        }

        [Then(@"Show the login option")]
        public void ThenShowTheLoginOption()
        {
            Assert.IsTrue(loginPage.showLoginOption());
        }

        [Given(@"Login application (.*) (.*)")]
        public void GivenLoginApplication(string username, string password)
        {
            WhenClickOnLoginOption();
            WhenEnterUsernameToLogin(username);
            WhenEnterPasswordToLogin(password);
            WhenClickOnLoginButton();
            Helper.wait(Helper.tLow);
        }
        [When(@"Send rest for login user (.*) (.*)")]
        public void WhenSendRestForLoginUser(string user, string password)
        {
            Rest.PostRequest(loginPage.createBodyForLoginRest(user, password), "https://api.demoblaze.com/login");
        }

    }
}
