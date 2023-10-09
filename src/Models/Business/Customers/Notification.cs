namespace Cims.WorkflowLib.Models.Customers
{
    /// <summary>
    /// 
    /// </summary>
    public class Notification
    {
        public string SenderId { get; set; } 
        public string ReceiverId { get; set; } 

        public string TitleText { get; set; } 
        public string BodyText { get; set; } 

        public System.DateTime SentDateTime { get; set; } 
        public System.DateTime ReceivedDateTime { get; set; } 

        public string Notes { get; set; } 
    }
}
