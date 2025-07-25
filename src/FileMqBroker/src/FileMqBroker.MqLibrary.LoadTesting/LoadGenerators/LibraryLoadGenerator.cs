using FileMqBroker.HttpService.Controllers;
using FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

namespace FileMqBroker.MqLibrary.LoadTesting.LoadGenerators;

/// <summary>
/// Load generator that calls the message broker adapter as a library component.
/// </summary>
public class LibraryLoadGenerator : ILoadGenerator
{
    private ILoadCalculation _loadCalculation;
    private InvestmentController _controller;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public LibraryLoadGenerator(
        ILoadCalculation loadCalculation, 
        InvestmentController controller)
    {
        _loadCalculation = loadCalculation;
        _controller = controller;
    }

    /// <summary>
    /// Method that generates a load for the selected generator type.
    /// </summary>
    public void GenerateLoad()
    {
        var currentLoad = _loadCalculation.CalculateLoad();

        // Load means the number of requests.
        // Accordingly, it is necessary to create a given number of client classes in a loop.
        var loadTasks = new Task[currentLoad];
        for (int i = 0; i < currentLoad; i++)
        {
            Task task = Task.Run(() =>
            {
                // _controller.GetInvestmentStats();
                _controller.RequestInvestment($"request: {i}");
            });
            loadTasks[i] = task;
        }
        Task.WaitAll(loadTasks);
    }
}