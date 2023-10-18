using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Products;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Responsibilities
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