using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.Products
{
    /// <summary>
    /// Associate table between project and employee.
    /// </summary>
    public class EmployeeProject : WfBusinessEntity, IWfBusinessEntity, ITemporalBusinessEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public Project? Project { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Employee? Employee { get; set; }

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