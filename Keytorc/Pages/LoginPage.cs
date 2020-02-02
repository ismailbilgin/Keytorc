using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Keytorc
{
    [TestClass]
    public class LoginPage
    {
       public IWebDriver driver;

        By login = By.ClassName("btnSignIn");
        By Username = By.Id("email");
        By Password = By.Id("password");
        By loginButton = By.Id("loginButton");


        string userName = "ENTER YOUR USERNAME HERE.! ";
        string password = "ENTER YOUR PASSWORD HERE.! ";



        public  LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void signInButton()
        {
            driver.FindElement(login).Click();
        }

        public void typeUsername()
        {
            driver.FindElement(Username).SendKeys(userName);
        }

        public void typePassword()
        {
            driver.FindElement(Password).SendKeys(password);
        }

        public void clickOnLoginButton()
        {
            driver.FindElement(loginButton).Click();
        }



    }
}
