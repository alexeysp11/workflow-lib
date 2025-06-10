using System.ComponentModel.DataAnnotations;

namespace FileMqBroker.MqLibrary.Models;

/// <summary>
/// The type of the message file.
/// </summary>
public enum MessageFileType
{
    [Display(Name = "Request")]
    Request,

    [Display(Name = "Response")]
    Response
}