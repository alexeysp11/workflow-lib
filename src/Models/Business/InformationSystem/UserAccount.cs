namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccount
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
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserStatus Status { get; set; }
    }
}