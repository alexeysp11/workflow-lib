using FileMqBroker.MqLibrary.DAL;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.Tests.MqLibrary.Mocks.DAL;

/// <summary>
/// 
/// </summary>
public class MockMessageFileDAL : SqliteMessageFileDAL
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public MockMessageFileDAL() : base(new AppInitConfigs())
    {
    }

    /// <summary>
    /// Mock method for inserting the specified files in DB.
    /// </summary>
    public virtual void InsertMessageFileState(IReadOnlyList<MessageFile> fileMessages)
    {
        if (fileMessages == null)
            throw new System.ArgumentNullException(nameof(fileMessages));
        if (fileMessages.Count == 0)
            return;
        
        var sqlQuery = GenerateInsertSqlByFileMessages(fileMessages);

        // Query.
        System.Console.WriteLine($"sqlQuery: {sqlQuery.Query}");

        // Parameters.
        var parameterNames = sqlQuery.Parameters.ParameterNames;
        foreach (var parameterName in parameterNames)
        {
            var parameterValue = sqlQuery.Parameters.Get<object>(parameterName);
            System.Console.WriteLine($"parameterName: {parameterName}; parameterValue: {parameterValue}");
        }
    }
}