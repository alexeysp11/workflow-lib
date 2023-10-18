using System.Collections.Generic;
using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// Message to the customer.
    /// </summary>
    public class MessageToCustomer : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Subject of the message.
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Body of the message.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Category of the message.
        /// </summary>
        public MessageCategory MessageCategory { get; set; }

        /// <summary>
        /// Timestamp when the message was sent.
        /// </summary>
        public System.DateTime SentAt { get; set; }

        /// <summary>
        /// Timestamp when the message was received.
        /// </summary>
        public System.DateTime? ReceivedAt { get; set; }

        /// <summary>
        /// Is the message new.
        /// </summary>
        public bool IsNew { get; set; }

        /// <summary>
        /// Is the message deleted.
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Is the message received.
        /// </summary>
        public bool IsReceived { get; set; }

        /// <summary>
        /// Sende ID.
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// Collection of recipient IDs.
        /// </summary>
        public ICollection<string> RecipientIds { get; set; }

        /// <summary>
        /// User account of the sender.
        /// </summary>
        public virtual UserAccount Sender { get; set; }

        /// <summary>
        /// Collection of recipients.
        /// </summary>
        public virtual ICollection<Customer> Recipients { get; set; }
    }
}