namespace WorkflowLib.Examples.ServiceInteraction.Models
{
    /// <summary>
    /// General description of the business process state.
    /// </summary>
    public class BusinessProcessState : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public BusinessProcess BusinessProcess { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        public System.DateTime DateCreated { get; set; }
        
        /// <summary>
        /// Endpoint type.
        /// </summary>
        public EndpointType EndpointType { get; set; }
    }
}