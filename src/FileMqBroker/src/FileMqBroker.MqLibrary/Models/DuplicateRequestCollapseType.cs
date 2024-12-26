using System.ComponentModel.DataAnnotations;

namespace FileMqBroker.MqLibrary.Models;

/// <summary>
/// Implementation of the duplicate request collapse.
/// </summary>
public enum DuplicateRequestCollapseType
{
    [Display(Name = "Naive")]
    Naive,
    
    [Display(Name = "Advanced")]
    Advanced
}