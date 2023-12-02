using Cims.WorkflowLib.Models.ErrorHandling;
using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Network
{
    /// <summary>
    /// Represents any attempt to communcate with API server as an operation.
    /// </summary>
    public class ApiOperation
    {
        #region Validating endpoint applications
        /// <summary>
        /// Client application UID.
        /// </summary>
        public string ClientAppUid { get; set; }

        /// <summary>
        /// Server application UID.
        /// </summary>
        public string ServerAppUid { get; set; }

        /// <summary>
        /// Application UID, to which the request will be redirected.
        /// </summary>
        public string RedirectToAppUid { get; set; }
        #endregion  // Validating endpoint applications
        
        #region Method names
        /// <summary>
        /// Name of the method that should be executed to perform the operation.
        /// </summary>
        public string MethodName { get; set; }
        
        /// <summary>
        /// Description of the method that should be executed to perform the operation 
        /// (contextual name of the operation, e.g. "adding two values").
        /// </summary>
        public string MethodDescription { get; set; }
        #endregion  // Method names

        #region Messages between client and server 
        /// <summary>
        /// String representation of JSON object that is sent as a request to the server.
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// String representation of JSON object that is received as a response from the server.
        /// </summary>
        public string Response { get; set; }

        /// <summary>
        /// Object that is sent as a request to the server.
        /// </summary>
        public object RequestObject { get; set; }

        /// <summary>
        /// Object that is received as a response from the server.
        /// </summary>
        public object ResponseObject { get; set; }

        /// <summary>
        /// Boolean variable that is set by a server to indicate if the request is executed properly.
        /// </summary>
        public bool IsExecuted { get; set; }
        
        /// <summary>
        /// String representation of the status of the operation (e.g. executed, failed, pending).
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Additional information about the status of the operation.
        /// </summary>
        public string StatusDescription { get; set; }
        #endregion  // Messages between client and server 

        /// <summary>
        /// Property that could be used to measure performance of the API operation (execution time).
        /// </summary>
        public ExecutionTime ExecutionTime { get; set; }

        /// <summary>
        /// Exception that is occurred during execution of the API operation.
        /// </summary>
        public WorkflowException WorkflowException { get; set; }
    }
}