namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// Notification.
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// Sender ID.
        /// </summary>
        public long SenderId { get; set; }

        /// <summary>
        /// Receiver ID.
        /// </summary>
        public long ReceiverId { get; set; }

        /// <summary>
        /// Title text.
        /// </summary>
        public string TitleText { get; set; }

        /// <summary>
        /// Body text.
        /// </summary>
        public string BodyText { get; set; }

        /// <summary>
        /// Timestamp when the notification was sent.
        /// </summary>
        public System.DateTime SentDateTime { get; set; }
        
        /// <summary>
        /// Timestamp when the notification was received.
        /// </summary>
        public System.DateTime ReceivedDateTime { get; set; }

        /// <summary>
        /// Notes.
        /// </summary>
        public string Notes { get; set; }
    }
}
