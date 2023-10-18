namespace Cims.WorkflowLib.Models.Business.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class Notification
    {
        /// <summary>
        /// 
        /// </summary>
        public long SenderId { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public string ReceiverId { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string TitleText { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public string BodyText { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime SentDateTime { get; set; } 
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime ReceivedDateTime { get; set; } 

        /// <summary>
        /// 
        /// </summary>
        public string Notes { get; set; } 
    }
}
