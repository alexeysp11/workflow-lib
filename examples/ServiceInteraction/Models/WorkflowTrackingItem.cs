namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Represents an item used for tracking the progress of a workflow instance.
    /// </summary>
    public class WorkflowTrackingItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Gets or sets the workflow instance associated with this tracking item.
        /// </summary>
        public WorkflowInstance WorkflowInstance { get; set; }

        /// <summary>
        /// Gets or sets the active task within the workflow instance.
        /// </summary>
        public BusinessTask ActiveTask { get; set; }

        /// <summary>
        /// Gets or sets the date when the tracking item was created.
        /// </summary>
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// Gets or sets the status of the tracking item.
        /// </summary>
        public WorkflowTrackingItemStatus Status { get; set; }
    }
}