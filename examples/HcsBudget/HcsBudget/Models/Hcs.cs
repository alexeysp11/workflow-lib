namespace WorkflowLib.Examples.HcsBudget.Models
{
    public class Hcs 
    {
        public int HcsId { get; set; }
        public string Name { get; set; }
        public float Qty { get; set; }
        public float PriceUsd { get; set; }
        public string ParticipantName { get; set; }
        public float TotalPrice { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public int PeriodId { get; set; }

        public Hcs(int periodId)
        {
            PeriodId = periodId;
        }

        public Hcs(int hcsId, string name, float qty, float priceUsd, 
            string participantName, float totalPrice, int month, int year, 
            int periodId)
        {
            HcsId = hcsId;
            Name = name;
            Qty = qty;
            PriceUsd = priceUsd;
            ParticipantName = participantName;
            TotalPrice = totalPrice;
            Month = month;
            Year = year;
            PeriodId = periodId;
        }
    }
}