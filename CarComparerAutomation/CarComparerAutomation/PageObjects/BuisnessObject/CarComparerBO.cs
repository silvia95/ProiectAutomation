using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarComparerAutomation.PageObjects
{
    public class CarComparerBO
    {
        //elemente pentru calculator
        public string text_KmAn = "15000";
        public string text_Combustibil = "5";
        public string text_Varsta = "30";
        public string select_NrAni = "option[value='3']";

        //elemente pentru comparator
        public string select_clasa1 = "option[value='1']";
        public string select_subclasa1 = "option[value='1']";
        public string select_producator1 = "option[value='2']";
        public string select_model1 = "option[value='41']";
        public string select_clasa2 = "option[value='1']";
        public string select_subclasa2 = "option[value='1']";
        public string select_producator2 = "option[value='2']";
        public string select_model2 = "option[value='44']";
    }
}
