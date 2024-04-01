using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// Paycheck.
    /// </summary>
    public class Paycheck : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Date.
        /// </summary>
        public System.DateTime Date { get; private set; }

        /// <summary>
        /// Period.
        /// </summary>
        public Period Period { get; private set; }

        /// <summary>
        /// Working hours.
        /// </summary>
        public WorkingHours WorkingHours { get; private set; }

        /// <summary>
        /// Days off.
        /// </summary>
        public DaysOff DaysOff { get; private set; }

        /// <summary>
        /// Sub total payments.
        /// </summary>
        public SubTotalPayments SubTotalPayments { get; private set; }

        /// <summary>
        /// Total amount.
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public virtual Employee Employee { get; private set; }
    }
}