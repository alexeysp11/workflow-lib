using VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BLProcPipes;

namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.Controllers;

/// <summary>
/// An interface for providing implicit communication between services.
/// </summary>
public interface IImplicitService
{
    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    void MoveWorkflowInstanceNext(PipeDelegateParams parameters);
}