using System.Data; 
using System.Globalization; 
using Microsoft.Data.Sqlite;

namespace WorkflowLib.Examples.HcsBudget.Models.DbConnections
{
    public abstract class BaseDbConnection
    {
        private string PathToDb { get; set; } 

        private string[] PathsToDbFolder = new string[] { "data/", "../../../../data/" }; 
        private string[] PathsToSqlFolder = new string[] { "src/SQL/", "../../../SQL/" }; 

        protected void SetPathToDb()
        {
            bool isPassed = false; 
            foreach (string path in PathsToDbFolder)
            {
                try
                {
                    PathToDb = path + "app.db"; 
                    GetDataTable("SELECT 1"); 
                    isPassed = true; 
                    break; 
                }
                catch (System.Exception) {}
            }
            if (!isPassed)
            {
                throw new System.Exception("Unable to display tables located in the database"); 
            }
        }

        protected string GetSqlRequest(string filename)
        {
            string sqlRequest = string.Empty; 
            foreach (string path in PathsToSqlFolder)
            {
                try
                {
                    sqlRequest = System.IO.File.ReadAllText(path + filename); 
                    break; 
                }
                catch (System.Exception) {}
            }
            if (sqlRequest == string.Empty)
            {
                throw new System.Exception("Unable to display tables located in the database"); 
            }
            return sqlRequest; 
        }

        protected DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            var connectionStringBuilder = new SqliteConnectionStringBuilder();
            connectionStringBuilder.DataSource = PathToDb;
            using (var connection = new SqliteConnection(connectionStringBuilder.ConnectionString))
            {
                try
                {
                    connection.Open();
                    var selectCmd = connection.CreateCommand();
                    selectCmd.CommandText = sql; 
                    using (var reader = selectCmd.ExecuteReader())
                    {
                        dt.Load(reader);
                        return dt;
                    }
                }
                catch (System.Exception e)
                {
                    throw e; 
                }
            }
        }

        protected void ExecuteSql(string sql)
        {
            GetDataTable(sql); 
        }

        protected string ToTitleCase(string s)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower()); 
        }
    }
}