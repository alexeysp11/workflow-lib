using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.SocialCommunication;

namespace Cims.WorkflowLib.Models.Business.Processes
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
        /// 
        /// </summary>
        public ConnectorWF ConnectorWF { get; set; }

        /// <summary>
        /// Creation date.
        /// </summary>
        public System.DateTime CreationDate { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public Comment Comment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public WorkflowTrackingItemStatus Status { get; set; }
    }
}