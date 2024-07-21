namespace WorkflowLib.Examples.Delivering.ServiceInteraction.BL.BPInitializers;

/// <summary>
/// Details about initializing the deployed application.
/// </summary>
public class StartupInitDetails
{
    /// <summary>
    /// Application deployment type.
    /// </summary>
    public ApplicationDeploymentType ApplicationDeploymentType { get; set; }

    /// <summary>
    /// Application client type.
    /// </summary>
    public ApplicationClientType ApplicationClientType { get; set; }
}