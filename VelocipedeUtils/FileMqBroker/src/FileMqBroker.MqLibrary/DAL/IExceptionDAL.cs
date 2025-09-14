using System.Collections.Generic;

namespace FileMqBroker.MqLibrary.DAL;

public interface IExceptionDAL
{
    /// <summary>
    /// Method for inserting the specified exceptions into DB.
    /// </summary>
    void InsertExceptions(IReadOnlyList<string> exceptions);
}