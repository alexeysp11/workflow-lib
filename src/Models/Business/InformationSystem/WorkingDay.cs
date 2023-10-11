using Cims.WorkflowLib.Models.Business.InformationSystem;
using Cims.WorkflowLib.Models.Business.Products;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkingDay
    {
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Date { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkingDayOption WorkingDayOption { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int WorkHours { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int ExtraWorkHours { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string EmployeeId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string ProjectId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Employee Employee { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Project Project { get; private set; }
    }
}