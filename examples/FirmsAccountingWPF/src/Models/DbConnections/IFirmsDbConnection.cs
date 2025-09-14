using System.Collections.Generic;
using VelocipedeUtils.Examples.FirmsAccounting.Models.Data;

namespace VelocipedeUtils.Examples.FirmsAccounting.Models.DbConnections
{
    public interface IFirmsDbConnection
    {
#nullable enable
        List<FirmCity> GetFirmCity(string? firmName, 
            string? postCityName, string? jurCityName);
#nullable disable
        List<FirmCity> GetFirmCity();
    }
}