using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// 
    /// </summary>
    public class Message
    {
        /// <summary>
        /// 
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageCategory MessageCategory { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public long ChannelId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Channel Channel { get; set; }

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
        public string SenderId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RecipientId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Sender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual UserAccount Recipient { get; set; }
    }
}