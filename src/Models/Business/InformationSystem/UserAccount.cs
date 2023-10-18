namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public class UserAccount
    {
        /// <summary>
        /// ID of the user.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// UID of the user.
        /// </summary>
        public string Uid { get; set; }
        
        /// <summary>
        /// Description of the user.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Login of the user.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Photo of the user.
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Photo URL of the user.
        /// </summary>
        public string PhotoUrl { get; set; }

        /// <summary>
        /// Status of the user.
        /// </summary>
        public UserStatus Status { get; set; }
    }
}