using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.InformationSystem;
using WorkflowLib.Shared.Models.Business.Products;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Working day.
    /// </summary>
    public class WorkingDay : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Date.
        /// </summary>
        public System.DateTime? Date { get; set; }

        /// <summary>
        /// Working day option.
        /// </summary>
        public WorkingDayOption? WorkingDayOption { get; set; }

        /// <summary>
        /// Expected working hours.
        /// </summary>
        public WorkingHours? ExpectedWorkingHours { get; set; }

        /// <summary>
        /// Actual working hours.
        /// </summary>
        public WorkingHours? ActualWorkingHours { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public virtual Employee? Employee { get; set; }

        /// <summary>
        /// Project.
        /// </summary>
        public virtual Project? Project { get; set; }
    }
}