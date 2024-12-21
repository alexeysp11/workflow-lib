using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.Monetary
{
    /// <summary>
    /// Paycheck.
    /// </summary>
    public class Paycheck : WfBusinessEntity, IWfBusinessEntity, ITemporalWfBusinessEntity
    {
        /// <summary>
        /// Date.
        /// </summary>
        public System.DateTime Date { get; private set; }

        /// <summary>
        /// Working hours.
        /// </summary>
        public WorkingHours WorkingHours { get; private set; }

        /// <summary>
        /// Days off.
        /// </summary>
        public DaysOff? DaysOff { get; private set; }

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
        
        /// <summary>
        /// Actual start date.
        /// </summary>
        public System.DateTime? DateStartActual { get; set; }
        
        /// <summary>
        /// Actual end date.
        /// </summary>
        public System.DateTime? DateEndActual { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? DateStartExpected { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? DateEndExpected { get; set; }
    }
}