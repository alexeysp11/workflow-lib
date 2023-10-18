namespace Cims.WorkflowLib.Models.Network
{
    /// <summary>
    /// Email configuration.
    /// </summary>
    public class EmailConfiguration
    {
        /// <summary>
        /// From.
        /// </summary>
        public string From { get; set; }
        
        /// <summary>
        /// SMTP server.
        /// </summary>
        public string SmtpServer { get; set; }
        
        /// <summary>
        /// Port.
        /// </summary>
        public int Port { get; set; }
        
        /// <summary>
        /// User name.
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Password.
        /// </summary>
        public string Password { get; set; }
    }
}