namespace Cims.WorkflowLib.Models.ErrorHandling
{
    /// <summary>
    /// 
    /// </summary>
    public class WorkflowException
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string FullMessage { get; set; }
    }
}
