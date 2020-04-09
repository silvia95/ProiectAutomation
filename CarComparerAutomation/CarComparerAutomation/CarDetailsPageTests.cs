using CarComparerAutomation.PageObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

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
            carDetailsPage.AddElement();

            string text = driver.SwitchTo().Alert().Text;

            Assert.IsTrue(text.Contains("Mașină adăugată."));
        }

        [TestMethod]
        public void Edit_Car()
        {
            carDetailsPage.goToDetailsPage();
            carDetailsPage.goToEditElement();
            carDetailsPage.EditElement();

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
                setupLogin.LoginApplication("test", "123456");
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

            System.Threading.Thread.Sleep(5000);
            Assert.AreEqual(true, carDetailsPage.CheckFileDownloaded("Lista_masini"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
