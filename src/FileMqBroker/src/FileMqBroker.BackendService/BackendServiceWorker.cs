using FileMqBroker.MqLibrary.Adapters.ReadAdapters;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.ResponseHandlers;

namespace FileMqBroker.BackendService;

/// <summary>
/// A worker that processes messages on the backend.
/// </summary>
public class BackendServiceWorker : BackgroundService
{
    private readonly ILogger<BackendServiceWorker> _logger;
    private IReadAdapter _readAdapter;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public BackendServiceWorker(
        ILogger<BackendServiceWorker> logger,
        IReadAdapter readAdapter,
        WriteBackResponseHandler responseHandler,
        AppInitConfigs appInitConfigs)
    {
        _logger = logger;
        _readAdapter = readAdapter;
        appInitConfigs.BackendContinuationDelegate = responseHandler.ContinuationMethod;
    }

    /// <summary>
    /// Method for executing worker functionality.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("BackendServiceWorker running at: {time}", DateTimeOffset.Now);
                _readAdapter.ReadMessageQueue();
                await Task.Delay(1000, stoppingToken);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}