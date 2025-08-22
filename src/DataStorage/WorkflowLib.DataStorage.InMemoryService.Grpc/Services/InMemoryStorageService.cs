using Grpc.Core;
using System.Threading.Tasks;
using WorkflowLib.DataStorage.Core.Tables;
using WorkflowLib.DataStorage.InMemoryService.Grpc;

namespace WorkflowLib.DataStorage.InMemoryService.Grpc.Services;

public class InMemoryStorageService : InMemoryStorage.InMemoryStorageBase
{
    private readonly InMemoryHashTable<string, string> _hashTable;
    private readonly ILogger<InMemoryStorageService> _logger;

    public InMemoryStorageService(ILogger<InMemoryStorageService> logger)
    {
        _hashTable = new InMemoryHashTable<string, string>();
        _logger = logger;
    }

    public override Task<SaveResponse> Save(SaveRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Save called with Key: {request.Key}, Value: {request.Value}");
        _hashTable.AddElement(request.Key, request.Value);
        return Task.FromResult(new SaveResponse { Success = true });
    }

    public override Task<SearchResponse> Search(SearchRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Search called with Key: {request.Key}");
        string? value = _hashTable.SearchElement(request.Key);
        bool found = value != null;

        return Task.FromResult(new SearchResponse { Value = value ?? "", Found = found });
    }

    public override Task<RemoveResponse> Remove(RemoveRequest request, ServerCallContext context)
    {
        _logger.LogInformation($"Remove called with Key: {request.Key}");
        bool success = _hashTable.RemoveElement(request.Key);
        return Task.FromResult(new RemoveResponse { Success = success });
    }
}
