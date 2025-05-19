using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.InformationSystem
{
    /// <summary>
    /// Establishes a dependency between the UserAccount and UserGroup classes.
    /// </summary>
    public class UserAccountGroup : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// User account.
        /// </summary>
        public UserAccount UserAccount { get; set; }

        /// <summary>
        /// User group.
        /// </summary>
        public UserGroup UserGroup { get; set; }
    }
}