using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
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

        private IWebElement buttonToList => driver.FindElement(By.Id("link_to_masini"));

        private By buttonToList_by = By.Id("link_to_masini");
        public void goToDetailsPage()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(buttonToList_by));
            buttonToList.Click();
        }

        private IWebElement details_table => driver.FindElement(By.Id("DataTables_Table_0_wrapper"));

        private By details_table_by = By.Id("DataTables_Table_0_wrapper");

        private IWebElement btnDelete => driver.FindElement(By.CssSelector(".btn_sterge_masina"));

        private By btnDelete_by = By.CssSelector(".btn_sterge_masina");

        private IWebElement btnEdit => driver.FindElement(By.ClassName("edit_model"));

        private By btnEdit_by = By.ClassName("edit_model");

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

        public void goToEditElement()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(details_table_by));
            LstCars[1].FindElement(By.ClassName("edit_model")).Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(btnEdit_by));
            //btnEdit.Click();
        }

        private IWebElement btnAdd => driver.FindElement(By.CssSelector(".btn_masini_adauga"));

        private By btnAdd_by = By.CssSelector(".btn_masini_adauga");

        private By modal_add_by = By.Id("modal_adaugare_editare");

        // Pagina 1
        private IWebElement ddlProducator => driver.FindElement(By.Id("1_producator"));
        private IWebElement txtModel => driver.FindElement(By.Id("1_model"));
        private IWebElement txtAn => driver.FindElement(By.Id("1_an_fabricatie"));
        private IWebElement txtPret => driver.FindElement(By.Id("1_pret"));
        private IWebElement chkLansat => driver.FindElement(By.Id("1_lansat"));
        private IWebElement txtDimMotor => driver.FindElement(By.Id("2_dim_motor"));
        private IWebElement ddlTipMotor => driver.FindElement(By.Id("2_tip_motor"));
        private IWebElement txtConsum => driver.FindElement(By.Id("2_consum"));
        private IWebElement ddlCarburant => driver.FindElement(By.Id("2_carburant"));
        private IWebElement txtCutie => driver.FindElement(By.Id("2_tip_cutie"));
        private IWebElement txtTrepte => driver.FindElement(By.Id("2_trepte_cutie"));
        private IWebElement txtCai => driver.FindElement(By.Id("2_cai_putere"));
        private IWebElement txtCuplu => driver.FindElement(By.Id("2_cuplu"));
        private IWebElement txtSuspensie => driver.FindElement(By.Id("2_suspensie"));
        private IWebElement ddlTurbina => driver.FindElement(By.Id("2_turbina"));
        private IWebElement ddlFaruri => driver.FindElement(By.Id("2_faruri"));
        private IWebElement ddlSenzori => driver.FindElement(By.Id("2_senzori"));
        private IWebElement txtGreutate => driver.FindElement(By.Id("2_greutate"));

        //Pagina 2
        private IWebElement txtLungime => driver.FindElement(By.Id("3_lungime"));
        private IWebElement txtLatime => driver.FindElement(By.Id("3_latime"));
        private IWebElement txtInaltime => driver.FindElement(By.Id("3_inaltime"));
        private IWebElement txtCap_Portbagaj => driver.FindElement(By.Id("3_cap_portbagaj"));
        private IWebElement txtNrPortiere => driver.FindElement(By.Id("4_portiere"));
        private IWebElement chkAerConditionat => driver.FindElement(By.Id("4_ac"));
        private IWebElement ddlTipAerCond => driver.FindElement(By.Id("4_tip_ac"));
        private IWebElement chkComenziVolan => driver.FindElement(By.Id("4_comenzi_volan"));
        private IWebElement chkCruiseControl => driver.FindElement(By.Id("4_cruise_control"));
        private IWebElement ddlRatingSiguranta => driver.FindElement(By.Id("4_rating_siguranta"));
        private IWebElement chkIncalzireaScaune => driver.FindElement(By.Id("4_incalzire_scaune"));
        private IWebElement chkComputerBord => driver.FindElement(By.Id("4_computer_bord"));
        private IWebElement chkPlafonPanoramic => driver.FindElement(By.Id("4_plafon_panoramic"));
        private IWebElement ddlTapiterie => driver.FindElement(By.Id("4_tapiterie"));

        //Pagina 3
        private IWebElement chkEsp => driver.FindElement(By.Id("5_esp"));
        private IWebElement chkAbs => driver.FindElement(By.Id("5_abs"));
        private IWebElement chkLaneAssist => driver.FindElement(By.Id("5_lane_assist"));
        private IWebElement chkBrakeAssist => driver.FindElement(By.Id("5_brake_assist"));
        private IWebElement chkAsistentaUpDown => driver.FindElement(By.Id("5_asistenta_up_down"));

        //Pagina 4
        private IWebElement txtRca20 => driver.FindElement(By.Id("6_rca20"));
        private IWebElement txtRca40 => driver.FindElement(By.Id("6_rca40"));
        private IWebElement txtRca60 => driver.FindElement(By.Id("6_rca60"));


        private IWebElement btnContinua => driver.FindElement(By.ClassName("button_next"));
        private IWebElement btnSalveaza => driver.FindElement(By.ClassName("button_final"));
        private By Element_Pag1 = By.ClassName("temporar_2_tehnic");
        private By Element_Pag2 = By.ClassName("temporar_3_dimensiuni");
        private By Element_Pag3 = By.ClassName("temporar_4_confort");
        private By Element_Pag4 = By.ClassName("temporar_5_siguranta");
        private By Element_Pag5 = By.ClassName("temporar_6_rca");

        //elemente pentru download
        private IWebElement btnDownloadPDF => driver.FindElement(By.ClassName("buttons-pdf"));

        

        public void AddElement()
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

        public void EditElement()
        {
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

        public void Download_Car_Details()
        {
            btnDownloadPDF.Click();
        }

        public bool CheckFileDownloaded(string filename)
        {
            bool exist = false;
            string Path = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\Downloads";
            string[] filePaths = Directory.GetFiles(Path);
            foreach (string p in filePaths)
            {
                if (p.Contains(filename))
                {
                    FileInfo thisFile = new FileInfo(p);
                    if (thisFile.LastWriteTime.ToShortTimeString() == DateTime.Now.ToShortTimeString() ||
                    thisFile.LastWriteTime.AddMinutes(1).ToShortTimeString() == DateTime.Now.ToShortTimeString())
                    {
                        exist = true;
                    }
                    File.Delete(p);
                    break;
                }
            }
            return exist;
        }

        public bool Element_Exist()
        {
            return btnAdd.Displayed;
        }

        public void Check_Admin_Rights()
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(btnAdd_by));
        }


    }
}
