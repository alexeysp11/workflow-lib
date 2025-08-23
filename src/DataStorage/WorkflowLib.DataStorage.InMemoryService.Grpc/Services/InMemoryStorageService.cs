using Grpc.Core;
using Serilog;
using System.Threading.Tasks;
using WorkflowLib.DataStorage.Core.Tables;
using WorkflowLib.DataStorage.InMemoryService.Grpc;

namespace WorkflowLib.DataStorage.InMemoryService.Grpc.Services;

public class InMemoryStorageService : InMemoryStorage.InMemoryStorageBase
{
    private readonly InMemoryHashTable<string, string> _hashTable;
    private readonly string _environmentVariableName;

    public InMemoryStorageService(InMemoryHashTable<string, string> hashTable)
    {
        _hashTable = hashTable;
        _environmentVariableName = "ASPNETCORE_ENVIRONMENT";
    }

    public override Task<SaveResponse> Save(SaveRequest request, ServerCallContext context)
    {
        CheckIfRequestKeyIsNullOrEmpty(request.Key);
        string requestUid = GetRequestUid();
        try
        {
            _hashTable.AddElement(request.Key, request.Value);

            // Log the status.
            if (Environment.GetEnvironmentVariable(_environmentVariableName) == "Production")
            {
                Log.Information("Saved the record");
            }
            else
            {
                Log.Information($"[UID: {requestUid}] Saved the record (Key: '{request.Key}', Value: '{request.Value}')");
            }

            return Task.FromResult(new SaveResponse { Success = true });
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
        CheckIfRequestKeyIsNullOrEmpty(request.Key);
        string requestUid = GetRequestUid();
        try
        {
            string? value = _hashTable.SearchElement(request.Key);
            bool found = value != null;

            // Log the status.
            if (Environment.GetEnvironmentVariable(_environmentVariableName) == "Production")
            {
                Log.Information("Search the record");
            }
            else
            {
                Log.Information($"[UID: {requestUid}] Search the record (Key: '{request.Key}') - Found: {found}");
            }

            return Task.FromResult(new SearchResponse { Value = value ?? "", Found = found });
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
        CheckIfRequestKeyIsNullOrEmpty(request.Key);
        string requestUid = GetRequestUid();
        try
        {
            bool success = _hashTable.RemoveElement(request.Key);

            // Log the status.
            if (Environment.GetEnvironmentVariable(_environmentVariableName) == "Production")
            {
                Log.Information("Remove the record");
            }
            else
            {
                Log.Information($"[UID: {requestUid}] Remove the record (Key: '{request.Key}') - Status: {success}");
            }

            return Task.FromResult(new RemoveResponse { Success = success });
        }
        catch (Exception ex)
        {
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while removing element with Key: '{request.Key}'";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.Internal, errorMessage), ex.Message);
        }
    }

    private void CheckIfRequestKeyIsNullOrEmpty(string requestKey)
    {
        if (string.IsNullOrEmpty(requestKey))
        {
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Key cannot be null"));
        }
    }

    private string GetRequestUid()
    {
        return Environment.GetEnvironmentVariable(_environmentVariableName) == "Production"
            ? "N/A"
            : Guid.NewGuid().ToString();
    }
}
