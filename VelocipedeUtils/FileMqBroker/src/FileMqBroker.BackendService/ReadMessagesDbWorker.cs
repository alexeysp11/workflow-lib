using FileMqBroker.MqLibrary.QueueDispatchers;

namespace FileMqBroker.BackendService;

/// <summary>
/// A worker that gets messages from database.
/// </summary>
public class ReadMessagesDbWorker : BackgroundService
{
    private readonly ILogger<ReadMessagesDbWorker> m_logger;
    private IMqDispatcher m_dispatcher;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ReadMessagesDbWorker(
        ILogger<ReadMessagesDbWorker> logger,
        ReadMqDispatcher dispatcher)
    {
        m_logger = logger;
        m_dispatcher = dispatcher;
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
                m_logger.LogInformation("ReadMessagesDbWorker running at: {time}", DateTimeOffset.Now);
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