using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WorkflowLib.Examples.ServiceInteraction.Models;

namespace WorkflowLib.Examples.ServiceInteraction.Core.EndpointMemoryManagement;

/// <summary>
/// Class for managing a pool of endpoints.
/// </summary>
public class EndpointPool
{
    private ConcurrentDictionary<long, EndpointCollectionParameter> m_endpointParameters;
    private IReadOnlyDictionary<long, EndpointCollectionParameter> m_cachedEndpointParameters;

    /// <summary>
    /// Collection of endpoint parameters.
    /// </summary>
    public IReadOnlyDictionary<long, EndpointCollectionParameter> EndpointParameters
    {
        get
        {
            if (m_cachedEndpointParameters == null)
            {
                m_cachedEndpointParameters = new Dictionary<long, EndpointCollectionParameter>(m_endpointParameters);
            }
            return m_cachedEndpointParameters;
        }
    }

    /// <summary>
    /// Public constructor for the EndpointPool class.
    /// </summary>
    public EndpointPool()
    {
        m_endpointParameters = new ConcurrentDictionary<long, EndpointCollectionParameter>();
    }

    /// <summary>
    /// Add an endpoint to the pool.
    /// </summary>
    /// <param name="endpoint">Endpoint to add to the pool.</param>
    public void AddEndpointToPool(EndpointCollectionParameter endpoint)
    {
        if (!m_endpointParameters.ContainsKey(endpoint.Id))
        {
            m_endpointParameters.TryAdd(endpoint.Id, endpoint);
            m_cachedEndpointParameters = null;
        }
    }

    /// <summary>
    /// Get an endpoint from the pool by ID.
    /// </summary>
    /// <param name="endpointId">Endpoint ID.</param>
    /// <returns>Endpoint from the pool or null if not found.</returns>
    public EndpointCollectionParameter GetEndpointFromPool(long endpointId)
    {
        if (m_endpointParameters.ContainsKey(endpointId))
        {
            m_endpointParameters.TryGetValue(endpointId, out EndpointCollectionParameter endpointParameter);
            return endpointParameter;
        }
        return null;
    }

    /// <summary>
    /// Remove an endpoint from the pool by ID.
    /// </summary>
    /// <param name="endpointId">Identifier of the endpoint to delete.</param>
    public void RemoveEndpointFromPool(long endpointId)
    {
        if (m_endpointParameters.ContainsKey(endpointId))
        {
            m_endpointParameters.TryRemove(endpointId, out _);
            m_cachedEndpointParameters = null;
        }
    }
}
