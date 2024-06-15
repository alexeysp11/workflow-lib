using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using WorkflowLib.Models.Business.Processes;

namespace WorkflowLib.Shared.ServiceDiscoveryBpm.ObjectPooling;

/// <summary>
/// Class for managing a pool of business process transitions.
/// </summary>
public sealed class TransitionPool
{
    private ConcurrentDictionary<long, BusinessProcessStateTransition> m_prev2NextTransitions;
    private IReadOnlyDictionary<long, BusinessProcessStateTransition> m_cachedPrev2NextTransitions;

    /// <summary>
    /// Cached copy of collection of business process transitions.
    /// </summary>
    public IReadOnlyDictionary<long, BusinessProcessStateTransition> Prev2NextTranstions
    {
        get
        {
            if (m_cachedPrev2NextTransitions == null)
            {
                m_cachedPrev2NextTransitions = new Dictionary<long, BusinessProcessStateTransition>(m_prev2NextTransitions);
            }
            return m_cachedPrev2NextTransitions;
        }
    }

    /// <summary>
    /// Public constructor for the TransitionPool class.
    /// </summary>
    public TransitionPool()
    {
        m_prev2NextTransitions = new ConcurrentDictionary<long, BusinessProcessStateTransition>();
    }

    
    /// <summary>
    /// Add an transition to the pool.
    /// </summary>
    /// <param name="transition">Transition to add to the pool.</param>
    public void AddTransitionToPool(BusinessProcessStateTransition transition)
    {
        var previousId = (transition.Previous == null ? 0 : transition.Previous.Id);
        if (!m_prev2NextTransitions.ContainsKey(previousId))
        {
            m_prev2NextTransitions.TryAdd(previousId, transition);
            ClearCacheFields();
        }
    }

    /// <summary>
    /// Get next transition from the pool.
    /// </summary>
    public BusinessProcessStateTransition GetNextTransitionById(long transitionId)
    {
        if (!m_prev2NextTransitions.ContainsKey(transitionId))
            return null;
        return m_prev2NextTransitions[transitionId];
    }

    /// <summary>
    /// Clears fields that contain cached values.
    /// </summary>
    private void ClearCacheFields()
    {
        m_cachedPrev2NextTransitions = null;
    }
}