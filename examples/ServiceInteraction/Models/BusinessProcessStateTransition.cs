namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// General description of the business process state transition.
    /// </summary>
    public class BusinessProcessStateTransition : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public BusinessProcess? BusinessProcess { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessProcessState? FromState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BusinessProcessState? ToState { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime? DateCreated { get; set; }
    }
}