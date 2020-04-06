using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CarComparerAutomation.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System;

namespace CarComparerAutomation

{   
    [TestClass]
    public class CarComparrerTests
    {
        private IWebDriver driver;
        private CarComparerPage carComparerPage;
        private LoginPage setupLogin;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            carComparerPage = new CarComparerPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://andrei.webdesign-iasi.ro/");
            setupLogin = new LoginPage(driver);
            setupLogin.LoginApplication("admin", "123456");
        }

        [TestMethod]
        public void Positive_Compare_Cars()
        {
            carComparerPage.goToComparator();

            carComparerPage.SelectFirstCar("Sport", "Lux", "Aston Martin", "DB11");

            carComparerPage.SelectSecondCar("Automobile", "Clasa medie", "BMW", "Seria 3 350 Sedan");

            carComparerPage.CompareCars();

            var table_compare = carComparerPage.getComparer_Table();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(table_compare));

            Assert.IsTrue(carComparerPage.isVisibleComparer());
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
        
}
