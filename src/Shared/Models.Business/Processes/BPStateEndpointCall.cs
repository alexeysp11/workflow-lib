using WorkflowLib.Shared.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Shared.Models.Business.Processes
{
    /// <summary>
    /// Provides a many-to-many relationship between objects of the BusinessProcessState and EndpointCall classes.
    /// </summary>
    public class BPStateEndpointCall : WfBusinessEntity, IWfBusinessEntity
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