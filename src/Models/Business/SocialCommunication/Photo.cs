using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// Photo.
    /// </summary>
    public class Photo : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Date added.
        /// </summary>
        public System.DateTime DateAdded { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsMain { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string PublicId { get; set; }
        
        /// <summary>
        /// User account.
        /// </summary>
        public UserAccount User { get; set; }
        
        /// <summary>
        /// User ID.
        /// </summary>
        public long UserId { get; set; }
    }
}