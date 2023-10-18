using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageToCustomer
    {
        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageCategory MessageCategory { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime SentAt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ReceivedAt { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNew { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReceived { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public long SenderId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> RecipientIds { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Sender { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Customer Recipient { get; private set; }
    }
}