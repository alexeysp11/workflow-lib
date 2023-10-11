namespace Cims.WorkflowLib.Models.Business.Monetary
{
    public class SubTotalPayments
    {
        public decimal PayForHours { get; private set; }

        public decimal PayForBusinessTrip { get; private set; }

        public decimal PayForExtraHours { get; private set; }

        public decimal PayForHolidayHours { get; private set; }

        public decimal PayForPayedDaysOff { get; private set; }
    }
}