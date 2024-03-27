using System.Text;
using Microsoft.EntityFrameworkCore;
using WorkflowLib.Examples.ServiceInteraction.Core.Contexts;
using WorkflowLib.Examples.ServiceInteraction.Core.DAL;
using WorkflowLib.Examples.ServiceInteraction.Core.Resolvers;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Tests
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
    public class ExampleInstance : IExampleInstance
    {
        private DbContextOptions<ServiceInteractionContext> _contextOptions { get; set; }
        private ServiceResolver _serviceResolver { get; set; }

        /// <summary>
        /// Construstor by default.
        /// </summary>
        public ExampleInstance(
            DbContextOptions<ServiceInteractionContext> contextOptions,
            ServiceResolver serviceResolver)
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
            using var context = new ServiceInteractionContext(_contextOptions);
            
            var stringBuilder = new StringBuilder();

            var direction = CompareEndpointDirections.Destination;
            var endpointCallType = EndpointCallType.Monolith;

            var endpointCalls = context.EndpointCalls
                .Where(x => x.EndpointCallType == endpointCallType)
                .Include(x => x.BusinessProcessState)
                .Include(x => x.BusinessProcessStateTransition)
                .Include(x => x.EndpointTypeFrom)
                .Include(x => x.EndpointTypeTo)
                .ToList();
            if (endpointCalls == null || !endpointCalls.Any())
                throw new System.Exception("Collection of endpoint calls could not be null or empty");

            stringBuilder.Clear();
            foreach (var endpointCall in endpointCalls)
            {
                stringBuilder.Append("Endpoint call: #").Append(endpointCall.Id);

                // Call the next element.
                stringBuilder.Append("\n\t").Append("Next: ");
                var endpointNext = _serviceResolver.GetNextEndpoint(
                    endpointCallType, 
                    endpointCall.BusinessProcessState, 
                    endpointCall.BusinessProcessStateTransition);
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
            ServiceInteractionContext context,
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