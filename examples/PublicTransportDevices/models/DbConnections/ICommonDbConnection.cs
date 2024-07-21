using System.Data;

namespace WorkflowLib.Examples.PublicTransportDevices.DbConnections
{
    public interface ICommonDbConnection
    {
        DataTable ExecuteSqlCommand(string sqlRequest);
    }
}