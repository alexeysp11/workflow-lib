using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using VelocipedeUtils.Examples.PublicTransportDevices.Models;
using VelocipedeUtils.Examples.PublicTransportDevices.Models.Data;
using VelocipedeUtils.Examples.PublicTransportDevices.Models.Domain;

namespace VelocipedeUtils.Examples.PublicTransportDevices.WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceInfoController : ControllerBase
{
    private readonly ILogger<DeviceInfoController> _logger;
    private readonly DeviceInfoDb _deviceInfoDb;

    public DeviceInfoController(ILogger<DeviceInfoController> logger, DeviceInfoDb deviceInfoDb)
    {
        _logger = logger;
        _deviceInfoDb = deviceInfoDb;
    }

    [HttpGet(Name = "GetDeviceInfo")]
    public System.Data.DataTable Get()
    {
        var dt = new System.Data.DataTable();
        try
        {
            dt = _deviceInfoDb.GetDeviceInfo();
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}");
        }
        return dt;
    }

    [HttpPost(Name = "PostDeviceInfo")]
    public void Post([FromBody] DeviceInfo device)  
    {
        if (device == null) 
            return;
        try
        {
            _deviceInfoDb.InsertDeviceInfo(device);
        }
        catch (System.Exception ex)
        {
            System.Console.WriteLine($"Exception: {ex}");
        }
    }
}
