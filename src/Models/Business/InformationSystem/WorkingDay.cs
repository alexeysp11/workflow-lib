using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkingDay : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkingDayOption WorkingDayOption { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkingHours ExpectedWorkingHours { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkingHours ActualWorkingHours { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Project Project { get; set; }
    }
}