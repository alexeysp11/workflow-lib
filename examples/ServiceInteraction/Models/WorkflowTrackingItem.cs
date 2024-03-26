namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowTrackingItem : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkflowInstance WorkflowInstance { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessTask ActiveTask { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkflowTrackingItemStatus Status { get; set; }
    }
}