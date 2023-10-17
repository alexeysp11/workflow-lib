using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// 
    /// </summary>
    public class Photo
    {
        /// <summary>
        /// 
        /// </summary>
        public int id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// 
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
        /// 
        /// </summary>
        public UserAccount User { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int UserId { get; set; }
    }
}