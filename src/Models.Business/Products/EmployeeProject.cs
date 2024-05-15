using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Associate table between project and employee.
    /// </summary>
    public class EmployeeProject : BusinessEntityWF, IBusinessEntityWF
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
        /// 
        /// </summary>
        public System.DateTime? DateStarted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DateEnded { get; set; }
    }
}