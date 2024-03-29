namespace WorkflowLib.Examples.ServiceInteraction.BL;

/// <summary>
/// An interface for providing implicit communication between services.
/// </summary>
public interface IImplicitService
{
    /// <summary>
    /// Method to call the next service depending on the current state of the process.
    /// </summary>
    void CallNextService();

    /// <summary>
    /// Method for processing the previous service depending on the current state of the process.
    /// </summary>
    void ProcessPreviousService();
}