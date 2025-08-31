using Grpc.Net.Client;
using System.Threading.Tasks;
using WorkflowLib.DataStorage.InMemoryService.Grpc;

namespace WorkflowLib.DataStorage.InMemoryService.Clients
{
    public class InMemoryStorageClient : IInMemoryStorageClient
    {
        private readonly InMemoryStorage.InMemoryStorageClient _client;
        private readonly GrpcChannel _channel;

        public InMemoryStorageClient(string serverAddress)
        {
            _channel = GrpcChannel.ForAddress(serverAddress);
            _client = new InMemoryStorage.InMemoryStorageClient(_channel);
        }

        public InMemoryStorageClient(InMemoryStorage.InMemoryStorageClient client, GrpcChannel channel)
        {
            _channel = channel;
            _client = client;
        }

        public async Task<bool> Save(string key, string value)
        {
            var request = new SaveRequest { Key = key, Value = value };
            var response = await _client.SaveAsync(request);
            return response.Success;
        }

        public async Task<(string? Value, bool Found)> Search(string key)
        {
            var request = new SearchRequest { Key = key };
            var response = await _client.SearchAsync(request);
            return (response.Found ? response.Value : null, response.Found);
        }

        public async Task<bool> Remove(string key)
        {
            var request = new RemoveRequest { Key = key };
            var response = await _client.RemoveAsync(request);
            return response.Success;
        }

        public void Dispose()
        {
            _channel?.Dispose();
        }
    }
}
