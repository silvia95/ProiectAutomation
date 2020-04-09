using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using System.IO;
using System.Threading;

namespace CarComparerAutomation.PageObjects
{
    public class HomePage
    {
        private IWebDriver driver;
        //public SiteMenu menuItemControl => new LoggedInMenuItemControl(driver);

        //elemente pentru poza de profil
        private IWebElement btnSettings => driver.FindElement(By.ClassName("upload_photo"));
        private IWebElement btnSelectFile => driver.FindElement(By.Id("choose_file"));
        private IWebElement btnUpload => driver.FindElement(By.Id("upload"));
        private IWebElement Paragraph => driver.FindElement(By.Id("file_uploaded_succes"));

        private By btnSettings_by = By.ClassName("upload_photo");

        private By btnSelectFile_by = By.Id("choose_file");

        private By Modal_by = By.Id("modal_adauga_poza");

        private By Container_by = By.Id("control_main");

        public HomePage(IWebDriver browser)
        {
            this.driver = browser;
            //Explicit Wait
            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            //wait.Until(ExpectedConditions.ElementIsVisible(btnLogout));
        }

        private By btnLogout => By.ClassName("logout-button");

        public string existsBtnComparrer()
        {
            var BtnComparrerName = driver.FindElement(By.Id("link_to_comparator")).Text;
            return BtnComparrerName;
        }

        public string existsBtnLogout()
        {
            var BtnLogoutName = driver.FindElement(By.ClassName("logout-button")).Text;
            return BtnLogoutName;
        }

        public void Add_Profile_Picture()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));

            string RunningPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string fileName = string.Format("{0}Media\\pp.jpg", Path.GetFullPath(Path.Combine(RunningPath, @"..\..\")));

            wait.Until(ExpectedConditions.ElementIsVisible(btnSettings_by));
            btnSettings.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Modal_by));
            btnSelectFile.SendKeys(fileName);
            btnUpload.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Container_by));
        }

        public bool Paragraph_Displayed()
        {
            return Paragraph.Displayed;
        }
    }
}
