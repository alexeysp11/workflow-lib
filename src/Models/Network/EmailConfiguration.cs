namespace Cims.WorkflowLib.Models.Network
{
    /// <summary>
    /// 
    /// </summary>
    public class EmailConfiguration
    {
        /// <summary>
        /// 
        /// </summary>
        public string From { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string SmtpServer { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }
    }
}