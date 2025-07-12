using WorkflowLib.Shared.Models.Business.Customers;

namespace WorkflowLib.Shared.Models.Business.Projects
{
    /// <summary>
    /// Company project.
    /// </summary>
    public class CompanyProject : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Company.
        /// </summary>
        public Company? Company { get; set; }

        /// <summary>
        /// Project.
        /// </summary>
        public Project? Project { get; set; }
    }
}