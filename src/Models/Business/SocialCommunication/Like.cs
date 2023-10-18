using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business.SocialCommunication
{
    /// <summary>
    /// 
    /// </summary>
    public class Like
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Uid { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public LikeType LikeType { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int LikerId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public int LikeeId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int MessageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int PostId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount Liker { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public UserAccount Likee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public MessageWF MessageWF { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Post Post { get; set; }
    }
}