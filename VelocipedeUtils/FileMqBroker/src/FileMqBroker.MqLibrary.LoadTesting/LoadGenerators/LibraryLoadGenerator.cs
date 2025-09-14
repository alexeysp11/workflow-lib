using FileMqBroker.HttpService.Controllers;
using FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

namespace FileMqBroker.MqLibrary.LoadTesting.LoadGenerators;

/// <summary>
/// Load generator that calls the message broker adapter as a library component.
/// </summary>
public class LibraryLoadGenerator : ILoadGenerator
{
    private ILoadCalculation m_loadCalculation;
    private InvestmentController m_controller;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public LibraryLoadGenerator(
        ILoadCalculation loadCalculation, 
        InvestmentController controller)
    {
        m_loadCalculation = loadCalculation;
        m_controller = controller;
    }

    /// <summary>
    /// Method that generates a load for the selected generator type.
    /// </summary>
    public void GenerateLoad()
    {
        var currentLoad = m_loadCalculation.CalculateLoad();

        // Load means the number of requests.
        // Accordingly, it is necessary to create a given number of client classes in a loop.
        var loadTasks = new Task[currentLoad];
        for (int i = 0; i < currentLoad; i++)
        {
            Task task = Task.Run(() =>
            {
                // m_controller.GetInvestmentStats();
                m_controller.RequestInvestment($"request: {i}");
            });
            loadTasks[i] = task;
        }
        Task.WaitAll(loadTasks);
    }
}