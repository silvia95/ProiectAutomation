using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CarComparerAutomation.PageObjects;
using OpenQA.Selenium.Support.UI;
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
            setupLogin.LoginApplication(new LoginBO());
        }

        [TestMethod]
        public void Positive_Compare_Cars()
        {
            carComparerPage.goToComparator();
            
            carComparerPage.CompareCars(new CarComparerBO());
            carComparerPage.CompareSelectedCars();

            var table_compare = carComparerPage.getComparer_Table();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(table_compare));

            Assert.IsTrue(carComparerPage.isVisibleComparer());
        }

        [TestMethod]
        public void Positive_Calculator()
        {
            carComparerPage.goToComparator();

            carComparerPage.CompareCars(new CarComparerBO());
            carComparerPage.CompareSelectedCars();

            var table_compare = carComparerPage.getComparer_Table();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(table_compare));
            carComparerPage.Calculate(new CarComparerBO());
            var table_calculator = carComparerPage.getCalculator_Table();
            wait.Until(ExpectedConditions.ElementIsVisible(table_calculator));
            Assert.IsTrue(carComparerPage.isVisibleComparer());
        }

        [TestMethod]
        public void Negative_Compare_Cars()
        {
            carComparerPage.goToComparator();

            carComparerPage.FailedCompareCars(new CarComparerBO());
            carComparerPage.CompareSelectedCars();

            var table_compare = carComparerPage.getComparer_Table();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Alegeți ambele mașini pentru a compara!"));
        }

        [TestMethod]
        public void Negative_Calculator()
        {
            carComparerPage.goToComparator();

            carComparerPage.CompareCars(new CarComparerBO());
            carComparerPage.CompareSelectedCars();

            var table_compare = carComparerPage.getComparer_Table();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(table_compare));
            carComparerPage.Negative_Calculate(new CarComparerBO());

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Completați toți parametrii înainte de a calcula!"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
        
}
