namespace FileMqBroker.MqLibrary.KeyCalculations;

/// <summary>
/// Interface for key calculation.
/// </summary>
public interface IKeyCalculation
{
    /// <summary>
    /// Calculates the hash based on the input.
    /// </summary>
    string CalculateHash(string input);
}