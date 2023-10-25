using Cims.WorkflowLib.Models.Business;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Project phase.
    /// </summary>
    public class ProjectPhase : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Project.
        /// </summary>
        public Project Project { get; set; }

        /// <summary>
        /// Project plan item.
        /// </summary>
        public ProjectPlanItem ProjectPlanItem { get; set; }
    }
}