using FileMqBroker.MqLibrary.LoadTesting.LoadGenerators;

namespace FileMqBroker.MqLibrary.LoadTesting;

public class LoadTestingWorker : BackgroundService
{
    private readonly ILogger<LoadTestingWorker> _logger;
    private ILoadGenerator _loadGenerator;

    public LoadTestingWorker(
        ILogger<LoadTestingWorker> logger,
        ILoadGenerator loadGenerator)
    {
        _logger = logger;
        _loadGenerator = loadGenerator;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                _logger.LogInformation("LoadTestingWorker running at: {time}", DateTimeOffset.Now);
                _loadGenerator.GenerateLoad();
                await Task.Delay(1000, stoppingToken);
            }
            catch (System.Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
    }
}
