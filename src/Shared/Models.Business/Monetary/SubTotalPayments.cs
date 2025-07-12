namespace WorkflowLib.Shared.Models.Business.Monetary
{
    /// <summary>
    /// Sub total payments.
    /// </summary>
    public class SubTotalPayments
    {
        public decimal PayForHours { get; set; }

        public decimal PayForBusinessTrip { get; set; }

        public decimal PayForExtraHours { get; set; }

        public decimal PayForHolidayHours { get; set; }

        public decimal PayForPayedDaysOff { get; set; }
    }
}