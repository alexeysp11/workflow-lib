namespace VelocipedeUtils.Examples.Delivering.ServiceInteraction.BL.BPInitializers;

/// <summary>
/// Business process initializer.
/// </summary>
public interface IBPInitializer
{
    /// <summary>
    /// Common method for initialization of business process instance.
    /// </summary>
    void Initialize();
}