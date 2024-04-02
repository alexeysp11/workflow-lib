namespace WorkflowLib.Examples.ServiceInteraction.Monolith
{
    /// <summary>
    /// An interface that allows you to initialize this example and also start executing it.
    /// </summary>
    public interface IStartupInstance
    {
        /// <summary>
        /// A method that starts initialization and execution of this example.
        /// </summary>
        void Run();
    }
}