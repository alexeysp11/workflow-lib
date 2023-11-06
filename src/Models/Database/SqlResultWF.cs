using System.Data;
using Cims.WorkflowLib.Models.Performance;

namespace Cims.WorkflowLib.Models.Database 
{
    /// <summary>
    /// Result of the SQL query.
    /// </summary>
    public class SqlResultWF
    {
        /// <summary>
        /// Initial SQL.
        /// </summary>
        public string InitialSql { get; set; }

        /// <summary>
        /// Result of the SQL query that is represented as a reader.
        /// </summary>
        public object ReaderResult { get; set; }

        /// <summary>
        /// Result of the SQL query that is represented as a DataTable.
        /// </summary>
        public DataTable DataTableResult { get; set; }

        /// <summary>
        /// SQL query for creating a table that was retrieved from the database.
        /// </summary>
        public string CreateResultSql { get; set; }

        /// <summary>
        /// SQL query for inserting data that was retrieved from the database.
        /// </summary>
        public string InsertResultSql { get; set; }

        /// <summary>
        /// Execution time of the query.
        /// </summary>
        public ExecutionTime ExecutionTime { get; set; }
    }
}