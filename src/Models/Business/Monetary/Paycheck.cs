using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Monetary
{
    /// <summary>
    /// 
    /// </summary>
    public class Paycheck : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Date { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Period Period { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkingHours WorkingHours { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public DaysOff DaysOff { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public SubTotalPayments SubTotalPayments { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Total { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee Employee { get; private set; }
    }
}