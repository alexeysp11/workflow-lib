using System.ComponentModel.DataAnnotations;

namespace FileMqBroker.MqLibrary.Models;

/// <summary>
/// Message processing type.
/// </summary>
public enum MessageFileProcessingType
{
    /// <summary>
    /// The status of the message will always be logged into the database.
    /// </summary>
    [Display(Name = "Logging into database")]
    LoggingIntoDatabase,

    /// <summary>
    /// The message will be processed as it is found in the directory on the backend service side.
    /// The status of the message will never be logged into the database.
    /// </summary>
    [Display(Name = "Only directory")]
    OnlyDirectory
}