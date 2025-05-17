namespace WorkflowLib.UnifiedBusinessPlatform.DbInit.Dal
{
    /// <summary>
    /// DAO for initializing postgres database for UnifiedBusinessPlatform.
    /// </summary>
    internal static class PgDatabaseInitDao
    {
        /// <summary>
        /// Check if the database exists.
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        internal static bool CheckDbExists(string connectionString)
        {
            return true;
        }

        /// <summary>
        /// Create database.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static void CreateDb(string connectionString)
        {
            // 
        }

        /// <summary>
        /// Initialize general data.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static void InitData(string connectionString)
        {
            // 
        }

        /// <summary>
        /// Apply EF Core migrations.
        /// </summary>
        internal static void EfCoreMigrations()
        {
            // 
        }

        /// <summary>
        /// Update functions for organization items.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static void OrganizationItemsFunctions(string connectionString)
        {
            // 
        }

        /// <summary>
        /// Create user accounts.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static void UserAccounts(string connectionString)
        {
            // 
        }

        /// <summary>
        /// Create an absence list.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static void Absenses(string connectionString)
        {
            // 
        }

        /// <summary>
        /// Create a language list.
        /// </summary>
        /// <param name="connectionString"></param>
        internal static void Languages(string connectionString)
        {
            // 
        }
    }
}
