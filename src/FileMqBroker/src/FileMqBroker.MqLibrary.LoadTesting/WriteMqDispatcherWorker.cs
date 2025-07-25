using FileMqBroker.MqLibrary.QueueDispatchers;

namespace FileMqBroker.MqLibrary.LoadTesting;

public class WriteMqDispatcherWorker : BackgroundService
{
    private readonly ILogger<WriteMqDispatcherWorker> _logger;
    private IMqDispatcher _dispatcher;

    public WriteMqDispatcherWorker(
        ILogger<WriteMqDispatcherWorker> logger,
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
                _logger.LogInformation("WriteMqDispatcherWorker running at: {time}", DateTimeOffset.Now);
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
