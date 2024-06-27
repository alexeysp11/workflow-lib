namespace WorkflowLib.Examples.FirmsAccounting.Models.Data
{
    public class DocsCalendarSum
    {
        public int Year { get; set; }
        public float JanSum { get; set; }
        public float FebSum { get; set; }
        public float MarSum { get; set; }
        public float AprSum { get; set; }
        public float MaySum { get; set; }
        public float JunSum { get; set; }
        public float JulSum { get; set; }
        public float AugSum { get; set; }
        public float SepSum { get; set; }
        public float OctSum { get; set; }
        public float NovSum { get; set; }
        public float DecSum { get; set; }

        public DocsCalendarSum(int year, float janSum, float febSum, float marSum, 
            float aprSum, float maySum, float junSum, float julSum, float augSum, 
            float sepSum, float octSum, float novSum, float decSum)
        {
            Year = year; 
            JanSum = janSum; 
            FebSum = febSum; 
            MarSum = marSum; 
            AprSum = aprSum; 
            MaySum = maySum; 
            JunSum = junSum; 
            JulSum = julSum; 
            AugSum = augSum; 
            SepSum = sepSum; 
            OctSum = octSum; 
            NovSum = novSum; 
            DecSum = decSum; 
        }
    }
}