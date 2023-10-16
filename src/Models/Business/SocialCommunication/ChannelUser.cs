namespace jihadkhawaja.mobilechat.client.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelUser
    {
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public long ChannelId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public long UserId { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public bool IsAdmin { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}