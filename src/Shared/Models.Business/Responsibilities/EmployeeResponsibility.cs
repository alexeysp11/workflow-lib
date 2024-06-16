using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Products;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.Responsibilities
{
    /// <summary>
    /// Employee responsibility.
    /// </summary>
    public class EmployeeResponsibility : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Project.
        /// </summary>
        public Project? Project { get; set; }

        /// <summary>
        /// Skills required for the project/responsibility.
        /// </summary>
        public ICollection<Skill> Skills { get; set; }
    }
}