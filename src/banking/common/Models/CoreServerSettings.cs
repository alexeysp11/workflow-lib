namespace Banking.Common.Models
{
    /// <summary>
    /// Class for storing confidurations related to the core server
    /// </summary>
    public sealed class CoreServerSettings
    {
        /// <summary>
        /// HTTP address of the core server 
        /// </summary>
        public string ServerAddress { get; set; }
        /// <summary>
        /// Environment (test, production)
        /// </summary>
        public string Environment { get; set; }

        /// <summary>
        /// Collection of ATM's UID
        /// </summary>
        public string[] AtmUid { get; set; }
        /// <summary>
        /// Collection of EFTPOS's UID
        /// </summary>
        public string[] EftposUid { get; set; }
        
        /// <summary>
        /// HTTP paths that are available for ATM to reach 
        /// </summary>
        public string[] HttpPathsAtm { get; set; }
        /// <summary>
        /// HTTP paths that are available for EFTPOS to reach 
        /// </summary>
        public string[] HttpPathsEftpos { get; set; }
        /// <summary>
        /// HTTP paths that could be used for testing and debugging the server
        /// </summary>
        public string[] HttpPathsDbg { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool PrintWebPaths { get; set; }
    }
}
