namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// 
    /// </summary>
    public class UserFriend
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public long FriendUserId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsAccepted { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}