using System;
using System.Data; 
using Xunit;
using Cims.WorkflowLib.DbConnections; 

namespace Cims.Tests.WorkflowLib.DbConnections
{
    public class MssqlDbConnectionTest 
    {
        private string ConnectionString = "Data Source=LAPTOP\\SQLEXPRESS;Initial Catalog=RealEstate;Trusted_Connection=True;MultipleActiveResultSets=true"; 

        // 
        [Fact]
        public void ExecuteSqlCommand_CorrectConnectionString_DataRetrieved()
        {
            // Arrange 
            string employeeName = "test_employee"; 
            string sqlSelect = $"SELECT * FROM studying.dbo.emp WHERE name = '{employeeName}'"; 
            string sqlInsert = $"INSERT INTO studying.dbo.emp (emp_id, name) SELECT MAX(e.emp_id), '{employeeName}' FROM studying.dbo.emp e WHERE NOT EXISTS ({sqlSelect})"; 
            string sqlDelete = $"DELETE FROM studying.dbo.emp WHERE name = '{employeeName}'"; 

            ICommonDbConnection dbConnection = new MssqlDbConnection(ConnectionString); 

            // Act 
            dbConnection.ExecuteSqlCommand(sqlInsert); 
            DataTable table = dbConnection.ExecuteSqlCommand(sqlSelect); 
            System.Console.WriteLine(table); 
            dbConnection.ExecuteSqlCommand(sqlDelete); 

            // Assert 
            Assert.True(table.Rows[table.Rows.Count-1]["name"].ToString() == employeeName); 
        }
    }
}