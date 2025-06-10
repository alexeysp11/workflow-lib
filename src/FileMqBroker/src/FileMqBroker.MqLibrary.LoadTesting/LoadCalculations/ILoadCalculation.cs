namespace FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

/// <summary>
/// Interface for load calculation.
/// </summary>
public interface ILoadCalculation
{
    /// <summary>
    /// Returns the number of requests corresponding to the selected type of load testing.
    /// </summary>
    int CalculateLoad();
}