using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Replacement.
    /// </summary>
    public class Replacement : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// The number of working days for which the replacement mechanism must be completed 
        /// (reassigning tasks, informing users, etc.) before the actual start date of replacement.
        /// </summary>
        public int PreReplace { get; set; }
        
        /// <summary>
        /// Whether or not to duplicate messages to the Substitute, if "Yes" - the messages go to the Substitute and the Substitute.
        /// </summary>
        public bool DuplicateMessage { get; set; }
        
        /// <summary>
        /// Start date.
        /// </summary>
        public System.DateTime? DateStarted { get; set; }
        
        /// <summary>
        /// End date.
        /// </summary>
        public System.DateTime? DateEnded { get; set; }
        
        /// <summary>
        /// User who is replaced.
        /// </summary>
        public UserAccount? SourceUser { get; set; }
        
        /// <summary>
        /// User who is replacing the absent user.
        /// </summary>
        public UserAccount? TargetUser { get; set; }
        
        /// <summary>
        /// Status of the replacement.
        /// </summary>
        public ReplacementStatus Status { get; set; }
    }
}