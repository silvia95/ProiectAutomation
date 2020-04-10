using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CarComparerAutomation.PageObjects;

namespace CarComparerAutomation
{
    [TestClass]
    public class LoginTests
    {
        private IWebDriver driver;
        private LoginPage loginPage;


        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            loginPage = new LoginPage(driver);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://andrei.webdesign-iasi.ro/");
            //loginPage.menuItemControl.NavigateToLoginPage();
        }

        [TestMethod]
        public void Positive_Login()
        {
            loginPage.LoginApplication(new LoginBO());

            var expectedresult = "Comparator";
            var homepage = new HomePage(driver);

            Assert.AreEqual(expectedresult, homepage.existsBtnComparrer());
            
        }

        [TestMethod]
        public void Positive_Signup()
        {
            loginPage.RegisterUser(new LoginBO());

            var expectedresult = "Logout";
            var homepage = new HomePage(driver);
            Assert.AreEqual(expectedresult, homepage.existsBtnLogout());
        }

        [TestCleanup]
        public void CleanUp()
        {
            driver.Quit();
        }
    }
}
