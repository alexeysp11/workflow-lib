namespace Cims.WorkflowLib.Example01.FlowchartSteps
{
    /// <summary>
    /// Interface for implementing steps within the order delivery process.
    /// </summary>
    public interface IFlowchartStep
    {
        /// <summary>
        /// A method that allows you to begin a specific step within the order delivery process.
        /// </summary>
        void Start();
    }
}