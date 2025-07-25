using FileMqBroker.MqLibrary.QueueDispatchers;

namespace FileMqBroker.BackendService;

/// <summary>
/// A worker that writes messages back into directory.
/// </summary>
public class WriteMessagesDbWorker : BackgroundService
{
    private readonly ILogger<WriteMessagesDbWorker> _logger;
    private IMqDispatcher _dispatcher;

    public WriteMessagesDbWorker(
        ILogger<WriteMessagesDbWorker> logger,
        WriteMqDispatcher dispatcher)
    {
        _logger = logger;
        _dispatcher = dispatcher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("WriteMessagesDbWorker running at: {time}", DateTimeOffset.Now);
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
