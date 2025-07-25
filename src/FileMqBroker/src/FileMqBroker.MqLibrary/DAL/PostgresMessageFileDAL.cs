using System.Data;
using System.Text;
using Dapper;
using Npgsql;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.DAL;

/// <summary>
/// Defines the functionality required for communication with the database at the Data Access Layer (DAL) level 
/// as part of working with a message.
/// </summary>
public class PostgresMessageFileDAL : IMessageFileDAL
{
    #region Private fields
    private object _obj = new object();
    private readonly string _connectionString;
    private readonly string _requestMessageFiles = "RequestMessageFiles";
    private readonly string _responseMessageFiles = "ResponseMessageFiles";
    private readonly string _selectAllSQL = "SELECT m.Name, m.HttpMethod, m.HttpPath, m.MessageFileState FROM {0} m ";
    private readonly string _insertMessageSQL = "INSERT INTO {0} (Name, HttpMethod, HttpPath, MessageFileState) VALUES ";
    private readonly string _updateOldMessageSQL = "update RequestMessageFiles set MessageFileState = 6 where MessageFileState not in (6, 11, 12) and CreatedAt < now() - interval '5 second';";
    #endregion  // Private fields

    #region Constructors
    /// <summary>
    /// Default constructor.
    /// </summary>
    public PostgresMessageFileDAL(AppInitConfigs appInitConfigs)
    {
        _connectionString = appInitConfigs.DbConnectionString;
    }
    #endregion  // Constructors
    
    #region Public methods
    /// <summary>
    /// Method for inserting the specified files in DB.
    /// </summary>
    public virtual void InsertMessageFileState(IReadOnlyList<MessageFile> fileMessages)
    {
        if (fileMessages == null)
            throw new System.ArgumentNullException(nameof(fileMessages));
        if (fileMessages.Count == 0)
            return;
        
        var sqlQuery = GenerateInsertSqlByFileMessages(fileMessages);

        lock (_obj)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery.Query, sqlQuery.Parameters);
            }
        }
    }

    /// <summary>
    /// Method for updating state of old files.
    /// </summary>
    /// <remarks>This optimization is used for those files that take too long to process on the backend side.</remarks>
    public virtual void UpdateOldMessageFileState()
    {
        var sqlQuery = _updateOldMessageSQL;

        lock (_obj)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery);
            }
        }
    }

    /// <summary>
    /// Method for updating state of the specified files.
    /// </summary>
    public virtual void UpdateMessageFileState(IReadOnlyList<MessageFile> fileMessages)
    {
        if (fileMessages == null)
            throw new System.ArgumentNullException(nameof(fileMessages));
        if (fileMessages.Count == 0)
            return;
        
        var sqlQuery = GenerateUpdateSqlByFileNames(fileMessages);

        lock (_obj)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Execute(sqlQuery.Query, sqlQuery.Parameters);
            }
        }
    }

    /// <summary>
    /// Method for obtaining information about files.
    /// </summary>
    public virtual IReadOnlyList<MessageFile> GetMessageFileInfo(int pageSize, int pageNumber, MessageFileType messageFileType)
    {
        var sqlQuery = GenerateSelectSqlReadyToReadFiles(pageSize, pageNumber, messageFileType);

        IReadOnlyList<MessageFile> result;
        using (var connection = new NpgsqlConnection(_connectionString))
        {
            result = connection.Query<MessageFile>(sqlQuery).ToList();
        }
        return result;
    }
    #endregion  // Public methods

    #region Private methods
    /// <summary>
    /// Method for generating an SQL query for inserting data about a file.
    /// </summary>
    protected (string Query, DynamicParameters Parameters) GenerateInsertSqlByFileMessages(IReadOnlyList<MessageFile> fileMessages)
    {
        var queryParameters = new DynamicParameters();
        var stringBuilder = new StringBuilder();

        for (int i = 0; i < fileMessages.Count; i++)
        {
            var messageFileType = fileMessages[i].MessageFileType;
            stringBuilder.Append(string.Format(_insertMessageSQL, (messageFileType == MessageFileType.Request ? _requestMessageFiles : _responseMessageFiles)));
            stringBuilder.Append($"(@file_{i}_Name, @file_{i}_HttpMethod, @file_{i}_HttpPath, @file_{i}_FileState);");

            queryParameters.Add($"file_{i}_Name", fileMessages[i].Name);
            queryParameters.Add($"file_{i}_HttpMethod", fileMessages[i].HttpMethod);
            queryParameters.Add($"file_{i}_HttpPath", fileMessages[i].HttpPath);
            queryParameters.Add($"file_{i}_FileState", fileMessages[i].MessageFileState);
        }

        return (stringBuilder.ToString(), queryParameters);
    }

    /// <summary>
    /// Method for generating an SQL query for updating data about a file.
    /// </summary>
    protected (string Query, DynamicParameters Parameters) GenerateUpdateSqlByFileNames(IReadOnlyList<MessageFile> fileMessages)
    {
        var queryParameters = new DynamicParameters();
        var stringBuilder = new StringBuilder();

        for (int i = 0; i < fileMessages.Count; i++)
        {
            var table = fileMessages[i].MessageFileType == MessageFileType.Request ? _requestMessageFiles : _responseMessageFiles;
            stringBuilder.Append($"UPDATE {table} SET MessageFileState = @MessageFileState_{i} WHERE Name = @Name_{i};");
            
            queryParameters.Add($"MessageFileState_{i}", fileMessages[i].MessageFileState);
            queryParameters.Add($"Name_{i}", fileMessages[i].Name);
        }

        return (stringBuilder.ToString(), queryParameters);
    }

    /// <summary>
    /// Generates an SQL query to retrieve readable files.
    /// </summary>
    protected string GenerateSelectSqlReadyToReadFiles(int pageSize, int pageNumber, MessageFileType messageFileType)
    {
        if (pageSize <= 0)
            throw new System.ArgumentException("Page size should be greater than zero", nameof(pageSize));
        if (pageNumber <= 0)
            throw new System.ArgumentException("Page number should be greater than zero", nameof(pageNumber));
        
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Format(_selectAllSQL, (messageFileType == MessageFileType.Request ? _requestMessageFiles : _responseMessageFiles)));
        stringBuilder.Append(" WHERE m.MessageFileState = 6");
        stringBuilder.Append($" LIMIT {pageSize} OFFSET {pageSize * (pageNumber - 1)};");

        return stringBuilder.ToString();
    }
    #endregion  // Private methods
}