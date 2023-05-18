namespace Cims.WorkflowLib.Models
{
    /// <summary>
    /// Class for storing confidurations related to the core server
    /// </summary>
    public sealed class NetworkAppSettings
    {
        /// <summary>
        /// Network address of the server application
        /// </summary>
        public string ServerAddress { get; set; }

        /// <summary>
        /// Network address of the client application 
        /// </summary>
        public string CleintAddress { get; set; }
        
        /// <summary>
        /// Environment (test, production)
        /// </summary>
        public string Environment { get; set; }
        
        /// <summary>
        /// HTTP paths 
        /// </summary>
        public string[] HttpPaths { get; set; }
        
        /// <summary>
        /// HTTP paths used for testing and debugging the server
        /// </summary>
        public string[] HttpPathsDbg { get; set; }

        /// <summary>
        /// Allows to print web paths which API server uses to listen to requests 
        /// </summary>
        public bool PrintWebPaths { get; set; }

        /// <summary>
        /// Allows to print debug information about processing HTTP requests 
        /// </summary>
        public bool PrintHttpRequestProcInfo { get; set; }
    }
}
