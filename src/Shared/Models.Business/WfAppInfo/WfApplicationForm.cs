namespace WorkflowLib.Shared.Models.Business.WfAppInfo
{
    /// <summary>
    /// Information about the application form.
    /// </summary>
    public class WfApplicationForm : WfBusinessEntity, IWfBusinessEntity
    {
        /// <summary>
        /// Information about the application.
        /// </summary>
        public WfApplication WfApplication { get; set; }
    }
}