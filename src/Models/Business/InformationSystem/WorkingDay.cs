using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Working day.
    /// </summary>
    public class WorkingDay : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Date.
        /// </summary>
        public System.DateTime Date { get; set; }

        /// <summary>
        /// Working day option.
        /// </summary>
        public WorkingDayOption WorkingDayOption { get; set; }

        /// <summary>
        /// Expected working hours.
        /// </summary>
        public WorkingHours ExpectedWorkingHours { get; set; }

        /// <summary>
        /// Actual working hours.
        /// </summary>
        public WorkingHours ActualWorkingHours { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// Project.
        /// </summary>
        public virtual Project Project { get; set; }
    }
}