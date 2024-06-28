namespace WorkflowLib.Examples.PublicTransportDevices.Models.Data;

/// <summary>
/// Represents board computer 
/// </summary>
public class BoardComputerInfo
{
    /// </summary>
    /// Steering angle (measured in degrees)
    /// <summary>
    public double SteeringAngle { get; set; }
    /// <summary>
    /// Brake pressure (measured in bar)
    /// </summary>
    public double BrakePressureBar { get; set; }
    /// <summary>
    /// Velocity (measured in meter per second)
    /// </summary>
    public double Velocity { get; set; }
}