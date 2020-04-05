using OpenQA.Selenium;
using System;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace CarComparerAutomation.PageObjects
{
    class HomePage
    {
        private IWebDriver driver;
        //public SiteMenu menuItemControl => new LoggedInMenuItemControl(driver);
        

        public HomePage(IWebDriver browser)
        {
            driver = browser;
            //Explicit Wait
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementIsVisible(btnLogout));
        }

        private By btnLogout => By.ClassName("logout-button");

        public string existsBtnComparrer()
        {
            var BtnComparrerName = driver.FindElement(By.ClassName("btnComparator")).Text;
            return BtnComparrerName;
        }

        public string existsBtnLogout()
        {
            var BtnLogoutName = driver.FindElement(By.ClassName("logout-button")).Text;
            return BtnLogoutName;
        }

        //public AddressesPage NavigateToAddressesPage()
        //{
        //    BtnAddresses.Click();
        //    return new AddressesPage(driver);
        //}
    }
}
