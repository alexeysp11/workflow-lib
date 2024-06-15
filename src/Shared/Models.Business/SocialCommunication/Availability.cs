using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.SocialCommunication
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
        public string? StatusMessage { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public AvailabilityStatus Status { get; set; }
    }
}