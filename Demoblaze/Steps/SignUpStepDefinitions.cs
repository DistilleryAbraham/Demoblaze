using Demoblaze.Hooks;
using Demoblaze.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace Demoblaze.Steps
{
    [Binding]
    public class SignUpStepDefinitions : InitialHooks
    {
        MainPage mainPage = new MainPage(Driver);

        [Given(@"Open demoblaze application")]
        public void GivenOpenDemoblazeApplication()
        {
            Assert.IsTrue(mainPage.validateThemainPage(baseURL));
        }

        [When(@"Click on Sign up  option")]
        public void WhenClickOnSignUpOption()
        {
            mainPage.clickSignUp();
        }

        [When(@"Enter username to singUp (.*) (.*)")]
        public void WhenEnterUsernameToSingUp(string userName, string success)
        {
            if (success.Equals("yes"))
            {
                mainPage.enterUsername(userName);
            }
            else
            {
                mainPage.enterSameUsername(userName);
            }
        }

        [When(@"Enter password to singUp (.*) (.*)")]
        public void WhenEnterPasswordToSingUp(string password, string success)
        {
            if (success.Equals("yes"))
            {
                mainPage.enterPassword(password);
            }
            else
            {
                mainPage.enterSamePassword(password);
            }
        }

        [When(@"Click on Signup button")]
        public void WhenClickOnSignupButton()
        {
            mainPage.clickSignUpEnter();
        }

        [Then(@"Show the message for signup (.*)")]
        public void ThenShowTheMessageForSignup(string success)
        {
            Assert.IsTrue(mainPage.hasSignUMessage(success));
        }
    }
}
