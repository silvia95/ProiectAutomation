using CarComparerAutomation.PageObjects;
using CarComparerAutomation.PageObjects.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Threading;

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
            setupLogin.LoginApplication(new LoginBO(), "admin");
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
            carDetailsPage.AddElement(new CarDetailsBO());

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Mașină adăugată."));
        }

        [TestMethod]
        public void Edit_Car()
        {
            carDetailsPage.goToDetailsPage();
            carDetailsPage.goToEditElement();
            carDetailsPage.EditElement(new CarDetailsBO());

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Editare efectuată."));
        }

        [TestMethod]
        public void Check_Permissions()
        {
            bool element_present = true;
            carDetailsPage.goToDetailsPage();
            carDetailsPage.Check_Admin_Rights();
            if (carDetailsPage.Element_Exist())
            {
                setupLogin.user_logout();
                //folosind wait-ul functioneaza in medie in 4 din 5 cazuri
                //folosind thread.sleep functioneaza in 5 din 5 cazuri 
                //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
                Thread.Sleep(5000);
                setupLogin.LoginApplication(new LoginBO(), "test");
                carDetailsPage.goToDetailsPage();
                if (!carDetailsPage.Element_Exist())
                {
                    element_present = false;
                }
            }
            else
            {
                element_present = false;
            }

            Assert.AreEqual(false, element_present);
        }

        [TestMethod]
        public void Download_PDF ()
        {
            carDetailsPage.goToDetailsPage();
            carDetailsPage.Download_Car_Details();

            //ar trebui sa asteptam o scurta perioada pentru a se finaliza descarcarea
            Thread.Sleep(5000);
            //cu implicit wait nu functioneaza precum thread.sleep
            //driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Assert.AreEqual(true, carDetailsPage.CheckFileDownloaded("Lista_masini"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
