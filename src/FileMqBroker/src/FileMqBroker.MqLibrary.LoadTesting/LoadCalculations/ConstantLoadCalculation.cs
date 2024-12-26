using FileMqBroker.MqLibrary.LoadTesting.Models;

namespace FileMqBroker.MqLibrary.LoadTesting.LoadCalculations;

/// <summary>
/// 
/// </summary>
public class ConstantLoadCalculation : OneTimeLoadCalculation, ILoadCalculation
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public ConstantLoadCalculation(LoadConfigParams loadConfigParams) : base(loadConfigParams)
    {
    }
}