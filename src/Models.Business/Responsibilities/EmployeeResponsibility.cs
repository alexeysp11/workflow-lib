using System.Collections.Generic;
using WorkflowLib.Models.Business;
using WorkflowLib.Models.Business.Products;
using WorkflowLib.Models.Business.InformationSystem;

namespace WorkflowLib.Models.Business.Responsibilities
{
    /// <summary>
    /// Employee responsibility.
    /// </summary>
    public class EmployeeResponsibility : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Project.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Skills required for the project/responsibility.
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
    }
}