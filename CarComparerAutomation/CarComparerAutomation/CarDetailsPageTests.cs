using CarComparerAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarComparerAutomation
{
    [TestClass]
    public class CarDetailsPageTests
    {
        private IWebDriver driver;
        private CarDetailsPage carDetailsPage;
        private LoginPage setupLogin;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            carDetailsPage = new CarDetailsPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://andrei.webdesign-iasi.ro/");
            setupLogin = new LoginPage(driver);
            setupLogin.LoginApplication("admin", "123456");
        }

        [TestMethod]
        public void Delete_Car()
        {
            carDetailsPage.goToDetailsPage();
            carDetailsPage.DeleteElement();

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Ștergere efectuată."));
        }

        [TestMethod]
        public void Add_Car()
        {
            carDetailsPage.goToDetailsPage();
            carDetailsPage.AddElement_First();

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Mașină adăugată."));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
