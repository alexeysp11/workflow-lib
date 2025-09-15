using System.ComponentModel.DataAnnotations;

namespace FileMqBroker.MqLibrary.Models;

/// <summary>
/// The state of the message file.
/// </summary>
public enum MessageFileState
{
    [Display(Name = "Undefined")]
    Undefined = 0,

    [Display(Name = "Created")]
    Created = 1,

    [Display(Name = "Reading")]
    Reading = 2,

    [Display(Name = "Writing")]
    Writing = 3,

    [Display(Name = "Deleting")]
    Deleting = 4,

    [Display(Name = "Ready to Write")]
    ReadyToWrite = 5,

    [Display(Name = "Ready to Read")]
    ReadyToRead = 6,

    [Display(Name = "Ready to Delete")]
    ReadyToDelete = 7,

    [Display(Name = "Failed to Write")]
    FailedToWrite = 8,

    [Display(Name = "Failed to Read")]
    FailedToRead = 9,

    [Display(Name = "Failed to Delete")]
    FailedToDelete = 10,
    
    [Display(Name = "Processed")]
    Processed = 11,
    
    [Display(Name = "Deleted")]
    Deleted = 12
}