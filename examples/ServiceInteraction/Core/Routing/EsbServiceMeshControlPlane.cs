namespace WorkflowLib.Examples.ServiceInteraction.Core.Routing;

/// <summary>
/// Provides functionality for the service mesh control plane (receives information where to redirect the process 
/// and causes a redirect using EsbProxies).
/// </summary>
public class EsbServiceMeshControlPlane
{
    /// <summary>
    /// Load the process in its current state.
    /// </summary>
    public void LoadCurrentState(long workflowInstanceId, long userId)
    {
        var currentStateId = GetCurrentStateId(workflowInstanceId, userId);
    }

    /// <summary>
    /// Load a process in a specified state.
    /// </summary>
    public void LoadSpecifiedState(long workflowInstanceId, long businessStateId, long userId)
    {
        // 
    }

    /// <summary>
    /// Returns the current state ID of the specified process.
    /// </summary>
    public long GetCurrentStateId(long workflowInstanceId, long userId)
    {
        return 0;
    }

    /// <summary>
    /// Make changes related to the current state within the current process.
    /// </summary>
    public void PostCurrentState(long workflowInstanceId, long userId)
    {
        // 
    }

    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    public void CallNextService(long workflowInstanceId, long transitionId)
    {
        // 
    }

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    public void ProcessPreviousService(long workflowInstanceId = 0, long transitionId = 0)
    {
        // 
    }
}