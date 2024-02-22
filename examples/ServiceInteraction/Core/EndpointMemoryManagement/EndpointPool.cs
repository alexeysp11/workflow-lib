using System;
using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

/// <summary>
/// Class for managing a pool of endpoints.
/// </summary>
public class EndpointPool
{
    private static EndpointPool instance;
    private Dictionary<long, EndpointCollectionParameter> endpointPool;

    /// <summary>
    /// Private constructor for the EndpointPool class.
    /// </summary>
    private EndpointPool()
    {
        endpointPool = new Dictionary<long, EndpointCollectionParameter>();
    }

    /// <summary>
    /// Get a single instance of the EndpointPool class.
    /// </summary>
    /// <returns>An instance of the EndpointPool class.</returns>
    public static EndpointPool GetInstance()
    {
        if (instance == null)
        {
            instance = new EndpointPool();
        }
        return instance;
    }

    /// <summary>
    /// Add an endpoint to the pool.
    /// </summary>
    /// <param name="endpoint">Endpoint to add to the pool.</param>
    public void AddEndpointToPool(EndpointCollectionParameter endpoint)
    {
        if (!endpointPool.ContainsKey(endpoint.Id))
        {
            endpointPool.Add(endpoint.Id, endpoint);
        }
    }

    /// <summary>
    /// Get an endpoint from the pool by ID.
    /// </summary>
    /// <param name="endpointId">Endpoint ID.</param>
    /// <returns>Endpoint from the pool or null if not found.</returns>
    public EndpointCollectionParameter GetEndpointFromPool(long endpointId)
    {
        if (endpointPool.ContainsKey(endpointId))
        {
            return endpointPool[endpointId];
        }
        return null;
    }

    /// <summary>
    /// Remove an endpoint from the pool by ID.
    /// </summary>
    /// <param name="endpointId">Identifier of the endpoint to delete.</param>
    public void RemoveEndpointFromPool(long endpointId)
    {
        if (endpointPool.ContainsKey(endpointId))
        {
            endpointPool.Remove(endpointId);
        }
    }
}
