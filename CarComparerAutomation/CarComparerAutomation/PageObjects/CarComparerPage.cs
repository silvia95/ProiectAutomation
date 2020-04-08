using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        // elementele de tip selector pentru cele 8 ddl
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
        private IWebElement model_2 => driver.FindElement(By.Id("model_2"));
        private By b_model_2 => By.Id("model_2");
        private By btnToComparator => By.ClassName("btnComparator");

        //elemente pentru calculator
        private IWebElement txtKmAn => driver.FindElement(By.Id("km_an"));
        private IWebElement txtCombustibil => driver.FindElement(By.Id("pret_comb"));
        private IWebElement txtVarsta => driver.FindElement(By.Id("varsta"));
        private IWebElement chkRovinieta => driver.FindElement(By.Id("rovinieta"));
        private IWebElement ddlNrAni => driver.FindElement(By.Id("ani_calcul"));
        private IWebElement btnCalculeaza => driver.FindElement(By.ClassName("btn-calculator-apply"));

        private IWebElement BtnComparaMasini()
        {
            return driver.FindElement(By.ClassName("btn-compara"));
        }

        private IWebElement comparer_table => driver.FindElement(By.ClassName("comparator-container"));

        private By comparer_table_by = By.ClassName("comparator-container");

        private IWebElement RezultateCalc => driver.FindElement(By.ClassName("calculator_rezultate"));

        private By RezultateCalc_by = By.ClassName("calculator_rezultate");

        public By getComparer_Table()
        {
            return comparer_table_by;
        }

        public By getCalculator_Table()
        {
            return RezultateCalc_by;
        }

        public void goToComparator()        {            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));            wait.Until(ExpectedConditions.ElementIsVisible(btnToComparator));            buttonToComparator.Click();        }


        public void FailedCompareCars(string s_clasa_1, string s_clasa_2)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(car_selector_container));
            var select_class_1 = new SelectElement(clasa_1);
            select_class_1.SelectByText(s_clasa_1);
            var select_class_2 = new SelectElement(clasa_2);
            select_class_2.SelectByText(s_clasa_2);
        }


        public void CompareCars()
        {
            clasa_1.Click();
            clasa_1.FindElement(By.CssSelector("option[value='1']")).Click();

            subclasa_1.Click();
            subclasa_1.FindElement(By.CssSelector("option[value='1']")).Click();

            producator_1.Click();
            producator_1.FindElement(By.CssSelector("option[value='2']")).Click();

            model_1.Click();
            model_1.FindElement(By.CssSelector("option[value='41']")).Click();

            clasa_2.Click();
            clasa_2.FindElement(By.CssSelector("option[value='1']")).Click();

            subclasa_2.Click();
            subclasa_2.FindElement(By.CssSelector("option[value='1']")).Click();

            producator_2.Click();
            producator_2.FindElement(By.CssSelector("option[value='2']")).Click();

            model_2.Click();
            model_2.FindElement(By.CssSelector("option[value='44']")).Click();
            
        }

        public void Calculate()
        {
            txtKmAn.SendKeys("15000");
            txtCombustibil.SendKeys("5");
            txtVarsta.SendKeys("30");
            chkRovinieta.Click();
            ddlNrAni.Click();
            ddlNrAni.FindElement(By.CssSelector("option[value='3']"));
            btnCalculeaza.Click();
        }

        public void Negative_Calculate()
        {
            txtCombustibil.SendKeys("5");
            txtVarsta.SendKeys("30");
            chkRovinieta.Click();
            ddlNrAni.Click();
            ddlNrAni.FindElement(By.CssSelector("option[value='3']"));
            btnCalculeaza.Click();
        }

        public void CompareSelectedCars()
        {
            BtnComparaMasini().Click();
        }

        public bool isVisibleComparer()
        {
            return comparer_table.Displayed;
        }

        public bool isVisibleCalculator()
        {
            return RezultateCalc.Displayed;
        }
    }
}
