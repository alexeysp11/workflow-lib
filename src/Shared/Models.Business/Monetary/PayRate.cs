using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Monetary
{
    /// <summary>
    /// Pay rate.
    /// </summary>
    public class PayRate : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Boolean variable that shows if this is a base rate.
        /// </summary>
        public bool IsBaseRate { get; set; }

        /// <summary>
        /// Hour rate.
        /// </summary>
        public decimal? HourRate { get; set; }

        /// <summary>
        /// Extra hour rate.
        /// </summary>
        public decimal? ExtraHourRate { get; set; }

        /// <summary>
        /// Hoiday hour rate.
        /// </summary>
        public decimal? HoidayHourRate { get; set; }

        /// <summary>
        /// Business trip hour rate.
        /// </summary>
        public decimal? BusinessTripHourRate { get; set; }
    }
}