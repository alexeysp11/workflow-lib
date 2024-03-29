using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.Processes;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// Project plan item.
    /// </summary>
    public class ProjectPlanItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Priority.
        /// </summary>
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// Items.
        /// </summary>
        public ICollection<ProjectPlanItem> Items { get; set; }
    }
}