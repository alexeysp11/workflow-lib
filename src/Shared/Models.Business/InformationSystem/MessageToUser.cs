using System.Collections.Generic;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Message to user.
    /// </summary>
    public class MessageToUser : WfBusinessEntity, IWfBusinessEntity, ISendableWfBusinessEntity, IReceivableWfBusinessEntity
    {
        /// <summary>
        /// Subect.
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Body.
        /// </summary>
        public string? Body { get; set; }
        
        /// <summary>
        /// Message category.
        /// </summary>
        public MessageCategory? MessageCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Date the business entity was received.
        /// </summary>
        public System.DateTime? DateReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> RecipientIDs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<UserAccount> Recipients { get; set; }

        /// <summary>
        /// Date the business entity was sent.
        /// </summary>
        public System.DateTime? DateSent { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Sender { get; set; }
    }
}