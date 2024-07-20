using System.Collections.Generic;
using WorkflowLib.Examples.HcsBudget.ViewModels;

namespace WorkflowLib.Examples.HcsBudget.Models
{
    public class Month
    {
        public int PeriodId { get; private set; }
        public int MonthNo { get; private set; }
        public int Year { get; private set; }

        public string Label 
        {
            get
            {
                return English;
            }
        }

        private string English;
        private string German;
        private string Russian;
        private string Spanish;
        private string Portugues;
        private string French;
        private string Italian;

        public List<Hcs> HcsList = new List<Hcs>();

        public Month(int periodId, int monthNo, int year, string english, 
            string german, string russian, string spanish, string portugues, 
            string french, string italian)
        {
            PeriodId = periodId;
            MonthNo = monthNo;
            Year = year;

            English = english;
            German = german;
            Russian = russian;
            Spanish = spanish;
            Portugues = portugues;
            French = french;
            Italian = italian;
        }
    }
}