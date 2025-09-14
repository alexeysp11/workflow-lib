namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.InitializeDb
{
    /// <summary>
    /// The class that is responsible for initializing this example.
    /// </summary>
    public class StartupInstance : IStartupInstance
    {
        /// <summary>
        /// Responsible for launching the application.
        /// </summary>
        public void Run()
        {
            System.Console.WriteLine("Database initialization");
        }
    }
}