using System;
using System.Data; 
using Xunit;
using Cims.WorkflowLib.DbConnections; 

namespace Cims.Tests.WorkflowLib.DbConnections
{
    public class BaseDbConnectionTest
    {
        [Theory]
        [InlineData(null, "")]
        [InlineData(null, "TestName")]
        public void GetSqlFromDataTable_OneOfTheParametersIsNull_ReturnsException(DataTable dt, string tableName)
        {
            // Arrange 
            BaseDbConnection connection = new BaseDbConnection(); 

            // Act 
            Action act = () => connection.GetSqlFromDataTable(dt, tableName); 

            // Assert 
            System.Exception exception = Assert.Throws<System.Exception>(act);
        }
    }
}
