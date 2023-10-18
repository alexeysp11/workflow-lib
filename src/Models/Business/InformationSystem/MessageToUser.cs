using System.Collections.Generic;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Message to user.
    /// </summary>
    public class MessageToUser : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Subect.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body.
        /// </summary>
        public string Body { get; set; }
        
        /// <summary>
        /// Message category.
        /// </summary>
        public MessageCategory MessageCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime SentAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? ReceivedAt { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReceived { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<string> RecipientIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Sender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ICollection<UserAccount> Recipients { get; set; }
    }
}