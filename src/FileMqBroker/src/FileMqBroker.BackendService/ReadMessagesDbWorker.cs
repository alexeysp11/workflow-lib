using FileMqBroker.MqLibrary.QueueDispatchers;

namespace FileMqBroker.BackendService;

/// <summary>
/// A worker that gets messages from database.
/// </summary>
public class ReadMessagesDbWorker : BackgroundService
{
    private readonly ILogger<ReadMessagesDbWorker> _logger;
    private IMqDispatcher _dispatcher;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ReadMessagesDbWorker(
        ILogger<ReadMessagesDbWorker> logger,
        ReadMqDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
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
                _logger.LogInformation("ReadMessagesDbWorker running at: {time}", DateTimeOffset.Now);
                _dispatcher.ProcessMessageQueue();
                await Task.Delay(1000, stoppingToken);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}