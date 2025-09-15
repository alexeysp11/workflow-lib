using FileMqBroker.MqLibrary.QueueDispatchers;

namespace FileMqBroker.MqLibrary.LoadTesting;

public class WriteMqDispatcherWorker : BackgroundService
{
    private readonly ILogger<WriteMqDispatcherWorker> m_logger;
    private IMqDispatcher m_dispatcher;

    public WriteMqDispatcherWorker(
        ILogger<WriteMqDispatcherWorker> logger,
        WriteMqDispatcher dispatcher)
    {
        m_logger = logger;
        m_dispatcher = dispatcher;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                m_logger.LogInformation("WriteMqDispatcherWorker running at: {time}", DateTimeOffset.Now);
                m_dispatcher.ProcessMessageQueue();
                await Task.Delay(1000, stoppingToken);
            }
            catch (System.Exception ex)
            {
                m_logger.LogError(ex.ToString());
            }
        }
    }
}
