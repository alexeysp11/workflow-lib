using System.Data;

namespace VelocipedeUtils.Examples.PublicTransportDevices.DbConnections
{
    public interface ICommonDbConnection
    {
        DataTable ExecuteSqlCommand(string sqlRequest);
    }
}