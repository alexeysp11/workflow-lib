namespace FileMqBroker.MqLibrary.LoadTesting.LoadGenerators;

/// <summary>
/// Interface for load generation.
/// </summary>
public interface ILoadGenerator
{
    /// <summary>
    /// Method that generates a load for the selected generator type.
    /// </summary>
    void GenerateLoad();
}