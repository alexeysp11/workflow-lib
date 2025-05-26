using WorkflowLib.Shared.Models.Business.Projects;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.Shared.Models.Business.Responsibilities
{
    /// <summary>
    /// Employee responsibility.
    /// </summary>
    public class EmployeeResponsibility : WfBusinessEntity, IWfBusinessEntity
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