using Grpc.Core;
using Serilog;
using System.Threading.Tasks;
using WorkflowLib.DataStorage.Core.Tables;
using WorkflowLib.DataStorage.InMemoryService.Grpc;

namespace WorkflowLib.DataStorage.InMemoryService.Grpc.Services;

public class InMemoryStorageService : InMemoryStorage.InMemoryStorageBase
{
    private readonly InMemoryHashTable<string, string> _hashTable;

    public InMemoryStorageService(InMemoryHashTable<string, string> hashTable)
    {
        _hashTable = hashTable;
    }

    public override Task<SaveResponse> Save(SaveRequest request, ServerCallContext context)
    {
        string requestUid = Guid.NewGuid().ToString();
        try
        {
            if (string.IsNullOrEmpty(request.Key))
            {
                throw new ArgumentNullException(nameof(request.Key));
            }

            Log.Information($"[UID: {requestUid}] Save called with Key: '{request.Key}', Value: '{request.Value}'");
            _hashTable.AddElement(request.Key, request.Value);
            return Task.FromResult(new SaveResponse { Success = true });
        }
        catch (ArgumentNullException ex)
        {
            string errorMessage = $"[UID: {requestUid}] Key cannot be null";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.InvalidArgument, errorMessage), ex.Message);
        }
        catch (Exception ex)
        {
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while saving element (Key: '{request.Key}', Value: '{request.Value}')";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.Internal, errorMessage), ex.Message);
        }
    }

    public override Task<SearchResponse> Search(SearchRequest request, ServerCallContext context)
    {
        string requestUid = Guid.NewGuid().ToString();
        try
        {
            if (string.IsNullOrEmpty(request.Key))
            {
                throw new ArgumentNullException(nameof(request.Key));
            }

            Log.Information($"[UID: {requestUid}] Search called with Key: '{request.Key}'");
            string? value = _hashTable.SearchElement(request.Key);
            bool found = value != null;

            return Task.FromResult(new SearchResponse { Value = value ?? "", Found = found });
        }
        catch (ArgumentNullException ex)
        {
            string errorMessage = $"[UID: {requestUid}] Key cannot be null";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.InvalidArgument, errorMessage), ex.Message);
        }
        catch (Exception ex)
        {
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while searching for element with Key: '{request.Key}'";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.Internal, errorMessage), ex.Message);
        }
    }

    public override Task<RemoveResponse> Remove(RemoveRequest request, ServerCallContext context)
    {
        string requestUid = Guid.NewGuid().ToString();
        try
        {
            if (string.IsNullOrEmpty(request.Key))
            {
                throw new ArgumentNullException(nameof(request.Key));
            }

            Log.Information($"[UID: {requestUid}] Remove called with Key: '{request.Key}'");
            bool success = _hashTable.RemoveElement(request.Key);
            return Task.FromResult(new RemoveResponse { Success = success });
        }
        catch (ArgumentNullException ex)
        {
            string errorMessage = $"[UID: {requestUid}] Key cannot be null";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.InvalidArgument, errorMessage), ex.Message);
        }
        catch (Exception ex)
        {
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while removing element with Key: '{request.Key}'";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.Internal, errorMessage), ex.Message);
        }
    }
}
