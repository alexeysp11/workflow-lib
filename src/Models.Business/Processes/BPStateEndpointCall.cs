using WorkflowLib.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Models.Business.Processes
{
    /// <summary>
    /// Provides a many-to-many relationship between objects of the BusinessProcessState and EndpointCall classes.
    /// </summary>
    public class BPStateEndpointCall : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// Gets or sets the associated business process state transition.
        /// </summary>
        public BusinessProcessState BusinessProcessState { get; set; }

        /// <summary>
        /// Gets or sets the associated endpoint call.
        /// </summary>
        public EndpointCall EndpointCall { get; set; }
    }
}