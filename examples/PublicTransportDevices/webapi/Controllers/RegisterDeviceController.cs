using System.Collections.Generic; 
using Microsoft.AspNetCore.Mvc;
using WorkflowLib.Examples.PublicTransportDevices.DbConnections; 
using WorkflowLib.Examples.PublicTransportDevices.Models.Data;

namespace WorkflowLib.Examples.PublicTransportDevices.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RegisterDeviceController : ControllerBase
{
    private readonly ILogger<RegisterDeviceController> _logger;
    private readonly ICommonDbConnection _dbConnection; 

    public RegisterDeviceController(ILogger<RegisterDeviceController> logger, ICommonDbConnection dbConnection)
    {
        _logger = logger;
        _dbConnection = dbConnection; 
    }

    [HttpGet(Name = "GetDevices")]
    public System.Data.DataTable Get()
    {
        var dt = new System.Data.DataTable(); 
        try
        {
            string sql = "select * from public.pt_device_info;"; 
            dt = _dbConnection.ExecuteSqlCommand(sql);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}"); 
        }
        return dt; 
    }

    [HttpPost(Name = "RegisterDevices")]
    public void PostRegister([FromBody] Device device)  
    {
        if (device == null) 
            return; 
        try
        {
            string sql = $"insert into public.pt_device (device_uid, device_type_id) values ('{device.Uid}', {(int)device.DeviceType}); "; 
            _dbConnection.ExecuteSqlCommand(sql); 
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}"); 
        }
    }
}
