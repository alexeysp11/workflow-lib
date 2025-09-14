using FileMqBroker.MqLibrary.LoadTesting.Models;

namespace FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

/// <summary>
/// Calculates the number of requests for a one-time increase in load.
/// </summary>
public class OneTimeLoadCalculation : ILoadCalculation
{
    private LoadConfigParams m_loadConfigParams;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public OneTimeLoadCalculation(LoadConfigParams loadConfigParams)
    {
        m_loadConfigParams = loadConfigParams;
    }

    /// <summary>
    /// Returns the number of requests corresponding to the selected type of load testing.
    /// </summary>
    public int CalculateLoad()
    {
        return m_loadConfigParams.DeltaMax;
    }
}