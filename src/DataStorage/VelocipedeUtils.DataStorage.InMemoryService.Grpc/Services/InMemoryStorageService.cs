using Grpc.Core;
using Serilog;
using VelocipedeUtils.DataStorage.Core.Tables;
using VelocipedeUtils.DataStorage.Models;

namespace VelocipedeUtils.DataStorage.InMemoryService.Grpc.Services;

public class InMemoryStorageService : InMemoryStorage.InMemoryStorageBase
{
    private readonly InMemoryHashTable<string, string> _hashTable;
    private readonly AppSettings _appSettings;
    private readonly string _environmentVariable;
    private object _obj;

    public InMemoryStorageService(AppSettings appSettings, InMemoryHashTable<string, string> hashTable)
    {
        if (hashTable == null)
        {
            throw new ArgumentNullException(nameof(hashTable));
        }
        if (appSettings == null)
        {
            throw new ArgumentNullException(nameof(appSettings));
        }
        if (string.IsNullOrEmpty(appSettings.EnvironmentVariable))
        {
            throw new ArgumentNullException(nameof(appSettings.EnvironmentVariable));
        }

        _obj = new object();
        _hashTable = hashTable;
        _appSettings = appSettings;
        _environmentVariable = appSettings.EnvironmentVariable;
    }

    public override Task<SaveResponse> Save(SaveRequest request, ServerCallContext context)
    {
        CheckIfRequestKeyIsNullOrEmpty(request.Key);
        string requestUid = GetRequestUid();
        try
        {
            _hashTable.AddElement(request.Key, request.Value);
            if (IsProductionEnvironment())
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
            if (IsProductionEnvironment())
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
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while searching for element (Key: '{request.Key}')";
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
            if (IsProductionEnvironment())
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
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while removing element (Key: '{request.Key}')";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.Internal, errorMessage), ex.Message);
        }
    }

    public override Task<IncrementResponse> Increment(IncrementRequest request, ServerCallContext context)
    {
        CheckIfRequestKeyIsNullOrEmpty(request.Key);
        string requestUid = GetRequestUid();
        try
        {
            HashTableIncrementResult incrementResult = IncrementElement(request.Key);
            if (IsProductionEnvironment())
            {
                Log.Information("Increment the record");
            }
            else
            {
                Log.Information($"[UID: {requestUid}] Increment the record (Key: '{request.Key}') - Result: [{incrementResult}]");
            }
            return Task.FromResult(new IncrementResponse
            {
                Value = incrementResult.Value,
                Success = incrementResult.Success
            });
        }
        catch (Exception ex)
        {
            string errorMessage = $"[UID: {requestUid}] An unexpected error occurred while incrementing element (Key: '{request.Key}')";
            Log.Error(ex, errorMessage);
            throw new RpcException(new Status(StatusCode.Internal, errorMessage), ex.Message);
        }
    }

    /// <summary>
    /// Increment an element in the hash table.
    /// </summary>
    private HashTableIncrementResult IncrementElement(string key)
    {
        lock (_obj)
        {
            if (_hashTable.ContainsElement(key))
            {
                string? value = _hashTable.SearchElement(key);
                if (int.TryParse(value?.ToString(), out int parsedValue))
                {
                    parsedValue += 1;
                    _hashTable.AddElement(key, parsedValue.ToString());
                    return new HashTableIncrementResult(parsedValue);
                }
                return new HashTableIncrementResult(null);
            }
            else
            {
                _hashTable.AddElement(key, "0");
                return new HashTableIncrementResult(0);
            }
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
        return IsProductionEnvironment() ? "N/A" : Guid.NewGuid().ToString();
    }

    private bool IsProductionEnvironment()
    {
        return _environmentVariable == "Production";
    }
}
