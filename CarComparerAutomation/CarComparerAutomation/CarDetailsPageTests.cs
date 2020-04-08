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
                carDetailsPage.user_logout();
                setupLogin.LoginApplication("test", "123456");
                carDetailsPage.goToDetailsPage();
                carDetailsPage.Check_Admin_Rights();
                if (carDetailsPage.Element_Exist())
                {
                    element_present = false;
                }
            }
            else
            {
                element_present = false;
            }

            Assert.IsTrue(element_present);
        }

        [TestMethod]
        public void Download_PDF ()
        {
            carDetailsPage.goToDetailsPage();

            String DownloadFolder = @"c:\temp\";
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", DownloadFolder);
            driver = new ChromeDriver(options);

            carDetailsPage.Download_Car_Details();

            System.Threading.Thread.Sleep(10000);
            Assert.IsTrue(File.Exists(@"c:\temp\Lista_masini.pdf"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
