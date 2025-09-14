using VelocipedeUtils.Examples.PublicTransportDevices.Models.Data.Enums;

namespace VelocipedeUtils.Examples.PublicTransportDevices.Models.Data;

public class Device
{
    public string Uid { get; set; } = "";
    public DeviceType DeviceType { get; set; }
}
