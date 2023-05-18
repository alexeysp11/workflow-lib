namespace Cims.WorkflowLib.Models 
{
    /// <summary>
    /// Represents any attempt to communcate with API server as an operation 
    /// </summary>
    public class ApiOperation
    {
        #region Validating endpoint applications
        /// <summary>
        /// Client application UID 
        /// </summary>
        public string ClientAppUid { get; set; }

        /// <summary>
        /// Server application UID 
        /// </summary>
        public string ServerAppUid { get; set; }
        #endregion  // Validating endpoint applications
        
        #region Method names
        /// <summary>
        /// Name of the method that should be executed to perform the operation 
        /// </summary>
        public string MethodName { get; set; }
        
        /// <summary>
        /// Description of the method that should be executed to perform the operation 
        /// (contextual name of the operation, e.g. "adding two values")
        /// </summary>
        public string MethodDescription { get; set; }
        #endregion  // Method names

        #region Messages between client and server 
        /// <summary>
        /// User request
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Server response 
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Boolean variable for indicating if the request is executed 
        /// </summary>
        public bool IsExecuted { get; set; }
        
        /// <summary>
        /// Status of the operation (e.g. executed, failed, pending)
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Additional information about the status of the operation (e.g. stacktrace)
        /// </summary>
        public string StatusDescription { get; set; }
        #endregion  // Messages between client and server 
    }
}