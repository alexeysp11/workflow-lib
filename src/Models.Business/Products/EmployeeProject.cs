using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Associate table between project and employee.
    /// </summary>
    public class EmployeeProject : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
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
        /// Factual start date.
        /// </summary>
        public System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        public System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? ExpectedEndDate { get; set; }
    }
}