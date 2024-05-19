using WorkflowLib.Models.Business;

namespace WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// Replacement.
    /// </summary>
    public class Replacement : BusinessEntityWF, IBusinessEntityWF, ITemporalBusinessEntityWF
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
        
        /// <summary>
        /// Factual start date.
        /// </summary>
        public System.DateTime? FactualStartDate { get; set; }
        
        /// <summary>
        /// Factual end date.
        /// </summary>
        public System.DateTime? FactualEndDate { get; set; }
        
        /// <summary>
        /// Expected start date.
        /// </summary>
        public System.DateTime? ExpectedStartDate { get; set; }
        
        /// <summary>
        /// Expected end date.
        /// </summary>
        public System.DateTime? ExpectedEndDate { get; set; }
    }
}