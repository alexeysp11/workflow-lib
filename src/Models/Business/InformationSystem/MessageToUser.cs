namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class MessageToUser
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
        public string SenderId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string RecipientId { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Sender { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Recipient { get; private set; }
    }
}