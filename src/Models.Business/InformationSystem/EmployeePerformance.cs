using System.Collections.Generic;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Employee performance.
    /// </summary>
    public class EmployeePerformance : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Managers who rated employee performance.
        /// </summary>
        public ICollection<Employee> Managers { get; set; }

        /// <summary>
        /// Employee.
        /// </summary>
        public Employee? Employee { get; set; }
        
        /// <summary>
        /// Performance rating.
        /// </summary>
        public int PerformanceRating { get; set; }
        
        /// <summary>
        /// Performance date.
        /// </summary>
        public System.DateTime PerformanceDate { get; set; }
    }
}