namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBusinessEntityWF
    {
        long Id { get; set; }
        string Uid { get; set; }
        string Name { get; set; }
        string Description { get; set; }
    }
}