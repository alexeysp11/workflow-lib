namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// Represents a transition between states of a business process with workflow functionality.
    /// </summary>
    public class BusinessProcessStateTransition : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Gets or sets the associated business process.
        /// </summary>
        public BusinessProcess? BusinessProcess { get; set; }

        /// <summary>
        /// Gets or sets the state the transition is coming from.
        /// </summary>
        public BusinessProcessState? FromState { get; set; }

        /// <summary>
        /// Gets or sets the state the transition is going to.
        /// </summary>
        public BusinessProcessState? ToState { get; set; }

        /// <summary>
        /// Gets or sets the date when the transition was created.
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}