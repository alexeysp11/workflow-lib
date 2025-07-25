using FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

namespace FileMqBroker.MqLibrary.LoadTesting.LoadGenerators;

/// <summary>
/// Load generator that calls the adapter for the message broker over HTTP.
/// </summary>
public class HttpLoadGenerator : ILoadGenerator
{
    private ILoadCalculation _loadCalculation;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public HttpLoadGenerator(ILoadCalculation loadCalculation)
    {
        _loadCalculation = loadCalculation;
    }

    /// <summary>
    /// Method that generates a load for the selected generator type.
    /// </summary>
    public void GenerateLoad()
    {
        var currentLoad = _loadCalculation.CalculateLoad();
        System.Console.WriteLine($"Current load: {currentLoad}");
    }
}