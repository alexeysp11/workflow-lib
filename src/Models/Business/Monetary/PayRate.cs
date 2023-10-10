namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class PayRate
    {
        /// <summary>
        /// 
        /// </summary>
        public bool IsBaseRate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal HourRate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal ExtraHourRate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal HoidayHourRate { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal BusinessTripHourRate { get; private set; }
    }
}