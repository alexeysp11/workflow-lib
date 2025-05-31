using Dapper;
using Npgsql;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.PixelTerminalUI.Dal.Auth
{
    public static class AuthDao
    {
        public static UserAccount? GetUserAccount(
            string connectionString,
            string username,
            string password)
        {
            string query = @"
select ua.*
from ""UserAccounts"" ua
where ua.""Login"" = @Username and ua.""Password"" = @Password
limit 1";
            using (var connection = new NpgsqlConnection(connectionString))
            {
                return connection.QueryFirstOrDefault<UserAccount>(query, new { Username = username, Password = password });
            }
        }
    }
}
