using WorkflowLib.Examples.PublicTransportDevices.DbConnections;
using WorkflowLib.Examples.PublicTransportDevices.Models.Data;

namespace WorkflowLib.Examples.PublicTransportDevices.Models.Domain;

public class DeviceInfoDb
{
    private readonly ICommonDbConnection _dbConnection;
    
    public DeviceInfoDb(ICommonDbConnection dbConnection)
    {
        _dbConnection = dbConnection;
    }

    public System.Data.DataTable GetDeviceInfo()
    {
        var dt = new System.Data.DataTable();
        try
        {
            string sql = "select * from public.pt_device;";
            dt = _dbConnection.ExecuteSqlCommand(sql);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}");
        }
        return dt;
    }

    public void InsertDeviceInfo(List<DeviceInfo> devices)
    {
        if (devices == null) 
            return;
        try
        {
            System.Console.WriteLine($"devices: {devices.Count} in InsertDeviceInfo");
            foreach (var device in devices)
            {
                InsertDeviceInfo(device);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}");
        }
    }

    public void InsertDeviceInfo(DeviceInfo device)
    {
        try
        {
            if (device != null && device.GeoCoordinate != null && device.DateTimeCreated != null)
            {
                var uid = device.Uid;
                var latitude = device.GeoCoordinate.Latitude;
                var longitude = device.GeoCoordinate.Longitude;
                var dtCreated = device.DateTimeCreated.ToString();
                var specificData = System.Text.Json.JsonSerializer.Serialize(device.SpecificData);
                string sql = @$"
insert into public.pt_device_info (device_uid, latitude, longitude, datetime_created, specific_data)
values('{uid}', {latitude}, {longitude}, '{dtCreated}', '{specificData}')";
                _dbConnection.ExecuteSqlCommand(sql);
            }
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}");
        }
    }
}