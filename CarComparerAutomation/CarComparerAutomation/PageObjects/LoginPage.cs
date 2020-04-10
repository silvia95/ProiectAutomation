using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CarComparerAutomation.PageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        //elemente pentru login
        private By username = By.CssSelector("input[name='username']");
        private By login_form_by => By.Id("login_form");


        //elemente pentru register
        private By new_username = By.Id("SignupUsername");

        //elemente pentru check permissions
        private IWebElement btnLogOut => driver.FindElement(By.ClassName("logout-button"));

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
            return driver.FindElement(By.CssSelector("p.create_account"));
        }

        private IWebElement ConfirmSignup()
        {
            return driver.FindElement(By.ClassName("creeaza_cont"));
        }

        public void LoginApplication(LoginBO login_data, string user_type = "admin")
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(username));
            if(user_type == "admin"){
                TxtUsername().SendKeys(login_data.login_username);
                TxtPassword().SendKeys(login_data.login_password);
            }
            else
            {
                TxtUsername().SendKeys(login_data.standard_username);
                TxtPassword().SendKeys(login_data.standard_password);
            }
            
            BtnLogin().Click();
        }

        public void RegisterUser(LoginBO register_data)
        {   

            BtnSignup().Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(new_username));
            TxtRegisterUsername().SendKeys(register_data.register_username);
            TxtEmail().SendKeys(register_data.register_email);
            TxtRegisterPassword().SendKeys(register_data.register_password);
            TxtConfirmPassword().SendKeys(register_data.register_confirmPassword);
            ConfirmSignup().Click();
        }

        public void user_logout()
        {
            btnLogOut.Click();
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementIsVisible(login_form_by));
        }
    }
}