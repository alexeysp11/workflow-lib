namespace Cims.WorkflowLib.Models.Business
{
    /// <summary>
    /// Interface that represents a business entity.
    /// </summary>
    public interface IBusinessEntityWF
    {
        long Id { get; set; }
        string Uid { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        BusinessEntityStatus BusinessEntityStatus { get; set; }
    }
}