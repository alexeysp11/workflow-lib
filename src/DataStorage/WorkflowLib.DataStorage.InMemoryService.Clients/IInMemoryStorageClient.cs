using System.Threading.Tasks;

namespace WorkflowLib.DataStorage.InMemoryService.Clients
{
    public interface IInMemoryStorageClient
    {
        Task<bool> Save(string key, string value);
        Task<(string? Value, bool Found)> Search(string key);
        Task<bool> Remove(string key);
    }
}