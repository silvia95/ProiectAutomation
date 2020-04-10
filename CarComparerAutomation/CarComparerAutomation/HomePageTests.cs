using CarComparerAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace CarComparerAutomation
{
    [TestClass]
    public class HomePageTests
    {

        private IWebDriver driver;
        private LoginPage setupLogin;
        private HomePage homePage;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://andrei.webdesign-iasi.ro/");
            setupLogin = new LoginPage(driver);
            setupLogin.LoginApplication(new LoginBO());
            homePage = new HomePage(driver);
        }

        [TestMethod]
        public void Upload_Photo()
        {
            homePage.Add_Profile_Picture();

            Assert.IsTrue(homePage.Paragraph_Displayed());
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
