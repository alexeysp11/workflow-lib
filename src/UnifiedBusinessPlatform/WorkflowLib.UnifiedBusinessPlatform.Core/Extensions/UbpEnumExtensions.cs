using System;
using WorkflowLib.Shared.Models.Business.Languages;

namespace WorkflowLib.UnifiedBusinessPlatform.Core.Extensions;

/// <summary>
/// Class of extension methods for enums.
/// </summary>
public static class UbpEnumExtensions
{
    /// <summary>
    /// Get enumeration of the language type.
    /// </summary>
    public static LanguageType GetLanguageTypeEnum(string input)
    {
        if (Enum.TryParse(input, out LanguageType convertedValue))
        {
            return convertedValue;
        }
        return LanguageType.English;
    }
}