using FileMqBroker.MqLibrary.Adapters.ReadAdapters;
using FileMqBroker.MqLibrary.Models;
using FileMqBroker.MqLibrary.ResponseHandlers;

namespace FileMqBroker.HttpService;

/// <summary>
/// Processes responses from the backend and sends them to the client application via HTTP.
/// </summary>
public class HttpResponseWorker : BackgroundService
{
    private readonly ILogger<HttpResponseWorker> m_logger;
    private IReadAdapter m_readAdapter;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public HttpResponseWorker(
        ILogger<HttpResponseWorker> logger,
        IReadAdapter readAdapter,
        HttpResponseHandler responseHandler,
        AppInitConfigs appInitConfigs)
    {
        m_logger = logger;
        m_readAdapter = readAdapter;
        appInitConfigs.BackendContinuationDelegate = responseHandler.ContinuationMethod;
    }

    /// <summary>
    /// Method for executing worker functionality.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            m_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            m_readAdapter.ReadMessageQueue();
            await Task.Delay(1000, stoppingToken);
        }
    }
}