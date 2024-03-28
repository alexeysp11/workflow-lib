using System.Collections.Generic;

namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Represents a specific instance of a workflow implementing a business process.
    /// </summary>
    public class WorkflowInstance : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Gets or sets a flag indicating if the workflow instance is in emulation mode.
        /// </summary>
        public bool IsEmulation { get; set; }

        /// <summary>
        /// Gets or sets the parent workflow instance if applicable.
        /// </summary>
        public WorkflowInstance? ParentInstance { get; set; }

        /// <summary>
        /// Gets or sets the business process associated with this workflow instance.
        /// </summary>
        public BusinessProcess BusinessProcess { get; set; }
    }
}