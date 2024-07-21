using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.Delivering.ServiceInteraction.BL.DbContexts;
using WorkflowLib.Shared.ServiceDiscoveryBpm.DAL;
using WorkflowLib.Shared.ServiceDiscoveryBpm.ServiceRegistry;
using WorkflowLib.Shared.Models.Network.MicroserviceConfigurations;

namespace WorkflowLib.Examples.Delivering.ServiceInteraction.Tests
{
    /// <summary>
    /// 
    /// </summary>
    internal enum CompareEndpointDirections
    {
        Source,
        Destination
    }

    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        private DbContextOptions<ServiceInteractionDbContext> _contextOptions { get; set; }
        private IEsbServiceRegistry _serviceResolver { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public StartupInstance(
            DbContextOptions<ServiceInteractionDbContext> contextOptions,
            IEsbServiceRegistry serviceResolver)
        {
            _contextOptions = contextOptions;
            _serviceResolver = serviceResolver;
        }

        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            TestMonolithEndpoints();
        }

        private void TestMonolithEndpoints()
        {
            using var context = new ServiceInteractionDbContext(_contextOptions);
            
            var stringBuilder = new StringBuilder();

            var direction = CompareEndpointDirections.Destination;
            var endpointCallType = EndpointCallType.Monolith;

            var stateTransitions = context.BusinessProcessStateTransitions
                .Where(x => x.FromState != null 
                    && x.EndpointCall != null 
                    && x.EndpointCall.EndpointCallType == endpointCallType 
                    && x.EndpointCall.EndpointTypeFrom != null 
                    && x.EndpointCall.EndpointTypeTo != null)
                .Include(x => x.FromState)
                .Include(x => x.EndpointCall)
                .Include(x => x.EndpointCall.EndpointTypeFrom)
                .Include(x => x.EndpointCall.EndpointTypeTo)
                .ToList();
            if (stateTransitions == null || !stateTransitions.Any())
                throw new System.Exception("Collection of state transitions could not be null or empty");

            stringBuilder.Clear();
            foreach (var stateTransition in stateTransitions)
            {
                var endpointCall = stateTransition.EndpointCall;
                stringBuilder.Append("Endpoint call: #").Append(endpointCall.Id);

                // Call the next element.
                stringBuilder.Append("\n\t").Append("Next: ");
                var endpointNext = _serviceResolver.GetNextEndpoint(
                    endpointCallType, 
                    stateTransition.FromState,
                    stateTransition);
                if (endpointNext == null)
                    stringBuilder.Append("Endpoint next could not be null.");
                else
                    CompareEndpoints(context, endpointNext, endpointCall.EndpointTypeTo, direction, stringBuilder);
                
                // Call the element specified explicitly by endpoint types.
                stringBuilder.Append("\n\t").Append("Explicit: ");
                var endpointExplicit = _serviceResolver.GetEndpointExplicit(
                    endpointCall.EndpointTypeFrom, 
                    endpointCall.EndpointTypeTo);
                if (endpointExplicit == null)
                    stringBuilder.Append("Endpoint explicit could not be null");
                else
                    CompareEndpoints(context, endpointNext, endpointCall.EndpointTypeTo, direction, stringBuilder);

                stringBuilder.Append("\n");
            }
            System.Console.WriteLine(stringBuilder.ToString());
        }

        private void CompareEndpoints(
            ServiceInteractionDbContext context,
            Endpoint endpointObtained,
            EndpointType endpointTypeInitial,
            CompareEndpointDirections direction,
            StringBuilder stringBuilder)
        {
            if (context == null)
                throw new System.ArgumentNullException(nameof(context));
            if (endpointObtained == null)
                throw new System.ArgumentNullException(nameof(endpointObtained));
            if (endpointTypeInitial == null)
                throw new System.ArgumentNullException(nameof(endpointTypeInitial));
            
            stringBuilder.Append("Endpoint: #").Append(endpointObtained.Id).Append(". ");
            var endpointTypeNext = context.Endpoints
                .Where(x => x.Id == endpointObtained.Id)
                .Select(x => x.EndpointType)
                .FirstOrDefault();
            if (endpointTypeNext == null)
            {
                stringBuilder.Append("null");
                return;
            }
            stringBuilder.Append("Endpoint types: ");
            stringBuilder.Append("obtained #").Append(endpointTypeNext == null ? "null" : endpointTypeNext.Id.ToString());
            stringBuilder.Append(" - ");
            stringBuilder.Append("initial #").Append(endpointTypeInitial.Id);
        }
    }
}