using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CarComparerAutomation.PageObjects
{
    class CarComparerPage
    {

        private IWebDriver driver;
        private By car_selector_container => By.ClassName("comparator-selector");
        public CarComparerPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement buttonToComparator => driver.FindElement(By.ClassName("btnComparator"));

        // elementele de tip selector
        private IWebElement clasa_1 => driver.FindElement(By.Id("clasa_1"));
        private By b_clasa_1 => By.Id("clasa_1");
        private IWebElement clasa_2 => driver.FindElement(By.Id("clasa_2"));
        private By b_clasa_2 => By.Id("clasa_2");
        private IWebElement subclasa_1 => driver.FindElement(By.Id("subclasa_1"));
        private By b_subclasa_1 => By.Id("subclasa_1");
        private IWebElement subclasa_2 => driver.FindElement(By.Id("subclasa_2"));
        private By b_subclasa_2 => By.Id("subclasa_2");
        private IWebElement producator_1 => driver.FindElement(By.Id("producator_1"));
        private By b_producator_1 => By.Id("producator_1");
        private IWebElement producator_2 => driver.FindElement(By.Id("producator_2"));
        private By b_producator_2 => By.Id("producator_2");
        private IWebElement model_1 => driver.FindElement(By.Id("model_1"));
        private By b_model_1 => By.Id("model_1");
        private IWebElement model_2 => driver.FindElement(By.Id("model_1"));
        private By b_model_2 => By.Id("model_2");
        private IWebElement BtnComparaMasini()
        {
            return driver.FindElement(By.ClassName("btn-compara"));
        }

        private IWebElement comparer_table => driver.FindElement(By.ClassName("comparator-container"));

        private By comparer_table_by = By.ClassName("comparator-container");
        public By getComparer_Table()
        {
            return comparer_table_by;
        }

        public void goToComparator()
        {
            buttonToComparator.Click();
        }

        public void SelectFirstCar(string s_clasa_1, string s_subclasa_1, string s_producator_1, string s_model_1)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(car_selector_container));
            var select_class_1 = new SelectElement(clasa_1);
            select_class_1.SelectByText(s_clasa_1);
            var select_subclass_1 = new SelectElement(subclasa_1);
            wait.Until(ExpectedConditions.ElementToBeSelected(b_subclasa_1));
            select_subclass_1.SelectByText(s_subclasa_1);
            var select_producator_1 = new SelectElement(producator_1);
            wait.Until(ExpectedConditions.ElementToBeSelected(b_producator_1));
            select_producator_1.SelectByText(s_producator_1);
            var select_model_1 = new SelectElement(model_1);
            wait.Until(ExpectedConditions.ElementToBeSelected(b_model_1));
            select_model_1.SelectByText(s_model_1);
        }

        public void SelectSecondCar(string s_clasa_2, string s_subclasa_2, string s_producator_2, string s_model_2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(car_selector_container));
            var select_class_2 = new SelectElement(clasa_2);
            select_class_2.SelectByText(s_clasa_2);
            var select_subclass_2 = new SelectElement(subclasa_2);
            wait.Until(ExpectedConditions.ElementToBeSelected(b_subclasa_2));
            select_subclass_2.SelectByText(s_subclasa_2);
            var select_producator_2 = new SelectElement(producator_2);
            wait.Until(ExpectedConditions.ElementToBeSelected(b_producator_2));
            select_producator_2.SelectByText(s_producator_2);
            var select_model_2 = new SelectElement(model_2);
            wait.Until(ExpectedConditions.ElementToBeSelected(b_model_2));
            select_model_2.SelectByText(s_model_2);
        }

        public void CompareCars()
        {
            BtnComparaMasini().Click();
        }

        public bool isVisibleComparer()
        {
            return comparer_table.Displayed;
        }
    }
}
