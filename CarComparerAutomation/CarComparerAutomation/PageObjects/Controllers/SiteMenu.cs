using OpenQA.Selenium;


namespace CarComparerAutomation.PageObjects.Controllers
{
    class SiteMenu
    {
        public IWebDriver driver;

        public SiteMenu(IWebDriver browser)
        {
            driver = browser;
        }

        private By home = By.ClassName("img_logo");
        private IWebElement BtnHome => driver.FindElement(home);

        public class LoggedInMenuItemControl : SiteMenu
        {
            private By comparer = By.ClassName("btnComparator");
            private IWebElement BtnComparrer => driver.FindElement(comparer);

            private By carList = By.CssSelector("a[href='masini']");
            private IWebElement BtnCarList => driver.FindElement(carList);

            private By signOut = By.ClassName("logout-button");
            private IWebElement BtnSignOut => driver.FindElement(signOut);

            public LoggedInMenuItemControl(IWebDriver browser) : base(browser)
            {

            }

        }
    }  
}
