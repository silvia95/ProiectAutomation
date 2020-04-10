using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace CarComparerAutomation.PageObjects
{
    class CarComparerPage
    {

        private IWebDriver driver;
        
        public CarComparerPage(IWebDriver browser)
        {
            driver = browser;
        }

        private By car_selector_container => By.ClassName("comparator-selector");
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
        private IWebElement RezultateCalc => driver.FindElement(By.ClassName("calculator_rezultate"));

        private By RezultateCalc_by = By.ClassName("calculator_rezultate");

        //elemente pentru comparator
        private IWebElement comparer_table => driver.FindElement(By.ClassName("comparator-container"));

        private By comparer_table_by = By.ClassName("comparator-container");

        public By getComparer_Table()
        {
            return comparer_table_by;
        }

        public By getCalculator_Table()
        {
            return RezultateCalc_by;
        }

        public void Calculate(CarComparerBO calculate_data)
        {
            txtKmAn.SendKeys(calculate_data.text_KmAn);
            txtCombustibil.SendKeys(calculate_data.text_Combustibil);
            txtVarsta.SendKeys(calculate_data.text_Varsta);
            chkRovinieta.Click();
            ddlNrAni.Click();
            ddlNrAni.FindElement(By.CssSelector(calculate_data.select_NrAni));
            btnCalculeaza.Click();
        }

        public void Negative_Calculate(CarComparerBO calculate_data)
        {
            txtCombustibil.SendKeys(calculate_data.text_Combustibil);
            txtVarsta.SendKeys(calculate_data.text_Varsta);
            chkRovinieta.Click();
            ddlNrAni.Click();
            ddlNrAni.FindElement(By.CssSelector(calculate_data.select_NrAni));
            btnCalculeaza.Click();
        }

        private IWebElement BtnComparaMasini()
        {
            return driver.FindElement(By.ClassName("btn-compara"));
        }

        public void goToComparator()        {            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));            wait.Until(ExpectedConditions.ElementIsVisible(btnToComparator));            buttonToComparator.Click();        }

        public void FailedCompareCars(CarComparerBO comparer_data)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(car_selector_container));
            clasa_1.Click();
            clasa_1.FindElement(By.CssSelector(comparer_data.select_clasa1)).Click();
            clasa_2.Click();
            clasa_2.FindElement(By.CssSelector(comparer_data.select_clasa2)).Click();
        }

        public void CompareCars(CarComparerBO comparer_data)
        {
            clasa_1.Click();
            clasa_1.FindElement(By.CssSelector(comparer_data.select_clasa1)).Click();

            subclasa_1.Click();
            subclasa_1.FindElement(By.CssSelector(comparer_data.select_subclasa1)).Click();

            producator_1.Click();
            producator_1.FindElement(By.CssSelector(comparer_data.select_producator1)).Click();

            model_1.Click();
            model_1.FindElement(By.CssSelector(comparer_data.select_model1)).Click();

            clasa_2.Click();
            clasa_2.FindElement(By.CssSelector(comparer_data.select_clasa2)).Click();

            subclasa_2.Click();
            subclasa_2.FindElement(By.CssSelector(comparer_data.select_subclasa2)).Click();

            producator_2.Click();
            producator_2.FindElement(By.CssSelector(comparer_data.select_producator2)).Click();

            model_2.Click();
            model_2.FindElement(By.CssSelector(comparer_data.select_model2)).Click();
            
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
