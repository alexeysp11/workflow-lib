using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// 
    /// </summary>
    public class Availability : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool ModifiedManually { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string StatusMessage { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public AvailabilityStatus Status { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime Modified { get; set; }
    }
}