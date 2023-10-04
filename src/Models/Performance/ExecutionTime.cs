namespace Cims.WorkflowLib.Models.Performance
{
    /// <summary>
    /// Property that shows the execution time of the operation (could be used for measuring performance).
    /// </summary>
    public class ExecutionTime
    {
        /// <summary>
        /// Timestamp when the operation started.
        /// </summary>
        public System.DateTime DateTimeBegin { get; set; }

        /// <summary>
        /// Timestamp when the operation ended.
        /// </summary>
        public System.DateTime DateTimeEnd { get; set; }

        /// <summary>
        /// Represents a time interval between the moment when the operation started and the moment when it ended.
        /// </summary>
        public System.TimeSpan TimeDifference { get { return DateTimeEnd - DateTimeBegin; } }
    }
}