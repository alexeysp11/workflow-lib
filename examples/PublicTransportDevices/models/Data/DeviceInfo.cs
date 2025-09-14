namespace VelocipedeUtils.Examples.PublicTransportDevices.Models.Data;

public class DeviceInfo
{
    public string Uid { get; set; } = "";
    public GeoCoordinate GeoCoordinate { get; set; }
    public System.DateTime DateTimeCreated { get; set; }
    public object SpecificData { get; set; }
}
