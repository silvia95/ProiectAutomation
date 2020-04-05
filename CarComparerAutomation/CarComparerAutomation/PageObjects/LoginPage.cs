using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
//using WaitHelpers.ExpectedConditions;

namespace CarComparerAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        //public LoggedOutMenuItemControl menuItemControl => new LoggedOutMenuItemControl(driver);

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By username = By.Id("session_email");
        private IWebElement TxtUsername()
        {
            return driver.FindElement(By.CssSelector("input[name='username']"));
        }

        private IWebElement TxtPassword()
        {
            return driver.FindElement(By.CssSelector("input[name='password']"));
        }

        private IWebElement BtnLogin()
        {
            return driver.FindElement(By.CssSelector("button[type = 'submit']"));
        }

        //public void NavigateToLoginPage()
        //{
        //    SiteMenu.NavigateToLoginPage();
        //}

        private IWebElement TxtRegisterUsername()
        {
            return driver.FindElement(By.Id("SignupUsername"));
        }

        private IWebElement TxtEmail()
        {
            return driver.FindElement(By.Id("userEmail"));
        }

        private IWebElement TxtRegisterPassword()
        {
            return driver.FindElement(By.Id("SignUpPassword"));
        }

        private IWebElement TxtConfirmPassword()
        {
            return driver.FindElement(By.Id("ConfirmPassword"));
        }

        private IWebElement BtnSignup()
        {
            return driver.FindElement(By.CssSelector("button[type = 'signup']"));
        }

        public void LoginApplication(string username, string password)
        {
            TxtUsername().SendKeys(username);
            TxtPassword().SendKeys(password);
            BtnLogin().Click();
        }

        public void RegisterUser(string username, string email, string password, string confirmPassword)
        {
            TxtRegisterUsername().SendKeys(username);
            TxtEmail().SendKeys(email);
            TxtRegisterPassword().SendKeys(password);
            TxtConfirmPassword().SendKeys(confirmPassword);
            BtnSignup().Click();
        }

    }
}