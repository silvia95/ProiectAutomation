using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;


namespace CarComparerAutomation.PageObjects
{
    public class CarDetailsPage
    {
        private IWebDriver driver;
        public CarDetailsPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement buttonToList => driver.FindElement(By.ClassName("brnComparator"));

        public void goToDetailsPage()
        {
            buttonToList.Click();
        }

        private IWebElement details_table => driver.FindElement(By.Id("DataTables_Table_0_wrapper"));

        private By details_table_by = By.Id("DataTables_Table_0_wrapper");

        private IWebElement btnDelete => driver.FindElement(By.CssSelector(".btn_sterge_masina"));

        private By btnDelete_by = By.CssSelector(".btn_sterge_masina");

        private IList<IWebElement> LstCars => driver.FindElements(By.CssSelector("#DataTables_Table_0 tbody tr"));

        public void DeleteElement()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(details_table_by));
            LstCars[1].FindElement(By.ClassName("delete_model")).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(btnDelete_by));
            btnDelete.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
        }

        private IWebElement btnAdd => driver.FindElement(By.CssSelector(".btn_masini_adauga"));

        private By btnAdd_by = By.CssSelector(".btn_masini_adauga");

        private By modal_add_by = By.CssSelector(".modal-body");

        // Pagina 1
        private IWebElement ddlProducator => driver.FindElement(By.CssSelector(".1_producator"));
        private IWebElement txtModel => driver.FindElement(By.CssSelector(".1_model"));
        private IWebElement txtAn => driver.FindElement(By.ClassName("1_an_fabricatie"));
        private IWebElement txtPret => driver.FindElement(By.ClassName("1_pret"));
        private IWebElement chkLansat => driver.FindElement(By.Id("1_lansat"));
        private IWebElement txtDimMotor => driver.FindElement(By.ClassName("2_dim_motor"));
        private IWebElement ddlTipMotor => driver.FindElement(By.ClassName("2_tip_motor"));
        private IWebElement txtConsum => driver.FindElement(By.ClassName("2_consum"));
        private IWebElement ddlCarburant => driver.FindElement(By.ClassName("2_carburant"));
        private IWebElement txtCutie => driver.FindElement(By.ClassName("2_tip_cutie"));
        private IWebElement txtTrepte => driver.FindElement(By.ClassName("2_trepte_cutie"));
        private IWebElement txtCai => driver.FindElement(By.ClassName("2_cai_putere"));
        private IWebElement txtCuplu => driver.FindElement(By.ClassName("2_cuplu"));
        private IWebElement txtSuspensie => driver.FindElement(By.ClassName("2_suspensie"));
        private IWebElement ddlTurbina => driver.FindElement(By.ClassName("2_turbina"));
        private IWebElement ddlFaruri => driver.FindElement(By.ClassName("2_faruri"));
        private IWebElement ddlSenzori => driver.FindElement(By.ClassName("2_senzori"));
        private IWebElement txtGreutate => driver.FindElement(By.ClassName("2_greutate"));

        //Pagina 2
        private IWebElement txtLungime => driver.FindElement(By.ClassName("3_lungime"));
        private IWebElement txtLatime => driver.FindElement(By.ClassName("3_latime"));
        private IWebElement txtInaltime => driver.FindElement(By.ClassName("3_inaltime"));
        private IWebElement txtCap_Portbagaj => driver.FindElement(By.ClassName("3_cap_portbagaj"));
        private IWebElement txtNrPortiere => driver.FindElement(By.ClassName("4_portiere"));
        private IWebElement chkAerConditionat => driver.FindElement(By.ClassName("4_ac"));
        private IWebElement ddlTipAerCond => driver.FindElement(By.ClassName("4_tip_ac"));
        private IWebElement chkComenziVolan => driver.FindElement(By.ClassName("4_comenzi_volan"));
        private IWebElement chkCruiseControl => driver.FindElement(By.ClassName("4_cruise_control"));
        private IWebElement ddlRatingSiguranta => driver.FindElement(By.ClassName("4_rating_siguranta"));
        private IWebElement chkIncalzireaScaune => driver.FindElement(By.ClassName("4_incalzire_scaune"));
        private IWebElement chkComputerBord => driver.FindElement(By.ClassName("4_computer_bord"));
        private IWebElement chkPlafonPanoramic => driver.FindElement(By.ClassName("4_plafon_panoramic"));
        private IWebElement ddlTapiterie => driver.FindElement(By.ClassName("4_tapiterie"));

        //Pagina 3
        private IWebElement chkEsp => driver.FindElement(By.Id("5_esp"));
        private IWebElement chkAbs => driver.FindElement(By.Id("5_abs"));
        private IWebElement chkLaneAssist => driver.FindElement(By.Id("5_lane_assist"));
        private IWebElement chkBrakeAssist => driver.FindElement(By.Id("5_brake_assist"));
        private IWebElement chkAsistentaUpDown => driver.FindElement(By.Id("5_asistenta_up_down"));

        //Pagina 4
        private IWebElement txtRca20 => driver.FindElement(By.ClassName("6_rca20"));
        private IWebElement txtRca40 => driver.FindElement(By.ClassName("6_rca40"));
        private IWebElement txtRca60 => driver.FindElement(By.ClassName("6_rca60"));


        private IWebElement btnContinua => driver.FindElement(By.ClassName("button_next"));
        private IWebElement btnSalveaza => driver.FindElement(By.ClassName("button_final"));
        private By Element_Pag1 = By.CssSelector(".2_dim_motor");
        private By Element_Pag2 = By.CssSelector(".3_lungime");
        private By Element_Pag3 = By.ClassName("4_portiere");
        private By Element_Pag4 = By.Id("5_esp");
        private By Element_Pag5 = By.ClassName("6_rca20");

        public void AddElement_First()
        {
            btnAdd.Click();
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(modal_add_by));
            wait.Until(ExpectedConditions.ElementIsVisible(Element_Pag1));

            //Pagina 1
            var ddlProd = new SelectElement(ddlProducator);
            ddlProd.SelectByText("Alfa Romeo");
            txtModel.SendKeys("4C");
            txtAn.SendKeys("2020");
            txtPret.SendKeys("30000");
            chkLansat.Click();
            txtDimMotor.SendKeys("6000");
            var ddlTMotor = new SelectElement(ddlTipMotor);
            ddlTMotor.SelectByText("Euro 4");
            txtConsum.SendKeys("7");
            var ddlCarb = new SelectElement(ddlCarburant);
            ddlCarb.SelectByText("Benzină");
            txtCutie.SendKeys("Automata");
            txtTrepte.SendKeys("8");
            txtCai.SendKeys("500");
            txtCuplu.SendKeys("340");
            txtSuspensie.SendKeys("Arcuri");
            var ddlTurb = new SelectElement(ddlTurbina);
            ddlTurb.SelectByText("Mono");
            var ddlFar = new SelectElement(ddlFaruri);
            ddlFar.SelectByText("LED");
            var ddlSenz = new SelectElement(ddlSenzori);
            ddlSenz.SelectByText("Senzori complet");
            txtGreutate.SendKeys("2000");

            btnContinua.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Element_Pag2));

            //Pagina 2
            txtLungime.SendKeys("300");
            txtLatime.SendKeys("140");
            txtInaltime.SendKeys("100");
            txtCap_Portbagaj.SendKeys("100");

            btnContinua.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Element_Pag3));

            //Pagina 3
            txtNrPortiere.SendKeys("8");
            chkAerConditionat.Click();
            var ddlAerCond = new SelectElement(ddlTipAerCond);
            ddlAerCond.SelectByText("Bizonal");
            chkComenziVolan.Click();
            chkCruiseControl.Click();
            var ddlRating = new SelectElement(ddlRatingSiguranta);
            ddlRating.SelectByText("2 stele");
            chkIncalzireaScaune.Click();
            chkComputerBord.Click();
            chkPlafonPanoramic.Click();
            var ddlTap = new SelectElement(ddlTapiterie);
            ddlTap.SelectByText("Alcantara");

            btnContinua.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Element_Pag4));

            //Pagina 4
            chkEsp.Click();
            chkAbs.Click();
            chkLaneAssist.Click();
            chkBrakeAssist.Click();
            chkAsistentaUpDown.Click();

            btnContinua.Click();
            wait.Until(ExpectedConditions.ElementIsVisible(Element_Pag5));

            //Pagina 5
            txtRca20.SendKeys("1400");
            txtRca40.SendKeys("8900");
            txtRca60.SendKeys("1100");

            btnSalveaza.Click();
            wait.Until(ExpectedConditions.AlertIsPresent());
        }
    }
}
