using Grpc.Core;
using WorkflowLib.DataStorage.InMemoryService.Grpc;

namespace WorkflowLib.DataStorage.InMemoryService.Grpc.Services;

public class InMemoryStorageService : InMemoryStorage.InMemoryStorageBase
{
    private readonly ILogger<InMemoryStorageService> _logger;

    public InMemoryStorageService(ILogger<InMemoryStorageService> logger)
    {
        _logger = logger;
    }

    public override Task<InMemoryReply> Save(SaveRequest request, ServerCallContext context)
    {
        return Task.FromResult(new InMemoryReply
        {
            Message = $"Key: {request.Key}, value: {request.Value}"
        });
    }

    public override Task<InMemoryReply> Search(SearchRequest request, ServerCallContext context)
    {
        return Task.FromResult(new InMemoryReply
        {
            Message = $"Key: {request.Key}"
        });
    }

    public override Task<InMemoryReply> Remove(RemoveRequest request, ServerCallContext context)
    {
        return Task.FromResult(new InMemoryReply
        {
            Message = $"Key: {request.Key}"
        });
    }
}
