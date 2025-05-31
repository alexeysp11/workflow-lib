using Dapper;
using Npgsql;
using WorkflowLib.Shared.Models.Business.InformationSystem;

namespace WorkflowLib.PixelTerminalUI.Dal.Auth
{
    public static class AuthDao
    {
        /// <summary>
        /// Get user account.
        /// </summary>
        /// <param name="connectionString">Connection string.</param>
        /// <param name="username">Username</param>
        /// <param name="password">Password</param>
        /// <returns>Object of user account</returns>
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
