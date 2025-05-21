using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business;
using WorkflowLib.Shared.Models.Business.Processes;

namespace WorkflowLib.Shared.Models.Business.Projects
{
    /// <summary>
    /// Project plan item.
    /// </summary>
    public class ProjectPlanItem : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Priority.
        /// </summary>
        public TaskPriority? Priority { get; set; }

        /// <summary>
        /// Items.
        /// </summary>
        public ICollection<ProjectPlanItem> Items { get; set; }
    }
}