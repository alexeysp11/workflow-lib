namespace Cims.WorkflowLib.Extensions
{
    public interface IConfigExtensions
    {
        T GetConfigSettings<T>(string filename, string sectionName);
    }
}