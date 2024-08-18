using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// User account.
    /// </summary>
    public class UserAccount : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Login of the user.
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        public string? Email { get; set; }

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Photo of the user.
        /// </summary>
        public byte[]? Photo { get; set; }

        /// <summary>
        /// Photo URL of the user.
        /// </summary>
        public string? PhotoUrl { get; set; }

        /// <summary>
        /// User groups.
        /// </summary>
        public ICollection<UserGroup> UserGroups { get; set; }

        /// <summary>
        /// Status of the user.
        /// </summary>
        public UserStatus Status { get; set; }

        /// <summary>
        /// Timestamp when the user was online the last time.
        /// </summary>
        public System.DateTime? LastSeenDt { get; set; }
    }
}