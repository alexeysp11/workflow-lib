using System.Collections.Generic;
using FileMqBroker.MqLibrary.Models;

namespace FileMqBroker.MqLibrary.DAL;

/// <summary>
/// Defines the functionality required for communication with the database at the Data Access Layer (DAL) level 
/// as part of working with a message.
/// </summary>
public interface IMessageFileDAL
{
    /// <summary>
    /// Method for inserting the specified files in DB.
    /// </summary>
    void InsertMessageFileState(IReadOnlyList<MessageFile> fileMessages);

    /// <summary>
    /// Method for updating state of old files.
    /// </summary>
    /// <remarks>This optimization is used for those files that take too long to process on the backend side.</remarks>
    void UpdateOldMessageFileState();

    /// <summary>
    /// Method for updating state of the specified files.
    /// </summary>
    void UpdateMessageFileState(IReadOnlyList<MessageFile> fileMessages);

    /// <summary>
    /// Method for obtaining information about files.
    /// </summary>
    IReadOnlyList<MessageFile> GetMessageFileInfo(int pageSize, int pageNumber, MessageFileType messageFileType);
}