using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class Paycheck 
    {
        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Period { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string WorkingHours { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string DaysOff { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubTotals { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee Employee { get; private set; }
    }
}