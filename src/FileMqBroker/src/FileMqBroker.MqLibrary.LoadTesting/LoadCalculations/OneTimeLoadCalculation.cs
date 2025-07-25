using FileMqBroker.MqLibrary.LoadTesting.Models;

namespace FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

/// <summary>
/// Calculates the number of requests for a one-time increase in load.
/// </summary>
public class OneTimeLoadCalculation : ILoadCalculation
{
    private LoadConfigParams _loadConfigParams;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public OneTimeLoadCalculation(LoadConfigParams loadConfigParams)
    {
        _loadConfigParams = loadConfigParams;
    }

    /// <summary>
    /// Returns the number of requests corresponding to the selected type of load testing.
    /// </summary>
    public int CalculateLoad()
    {
        return _loadConfigParams.DeltaMax;
    }
}