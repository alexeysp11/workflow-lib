using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.Products
{
    /// <summary>
    /// 
    /// </summary>
    public class ProjectPlanItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public TaskPriority Priority { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<ProjectPlanItem> Items { get; set; }
    }
}