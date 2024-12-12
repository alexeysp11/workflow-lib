using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Collections.Generic;
using WorkflowLib.Shared.Models.Business.Languages;
using WorkflowLib.Examples.UnifiedBusinessPlatform.Core.DbContexts;

namespace WorkflowLib.Examples.UnifiedBusinessPlatform.Core.Dal
{
    /// <summary>
    /// A class that provides general functionality for working with databases in the context of languages.
    /// </summary>
    public static class LanguageDal
    {
        /// <summary>
        /// Get a collection of labels for visual components from the database to implement language support.
        /// </summary>
        public static Dictionary<string, string> GetLanguageKvpByFormName(
            EmployeesMvcDbContext context,
            LanguageType languageType,
            string formName)
        {
            List<LanguageKeyValuePair> languageKvpList = context.LanguageKeyValuePairs
                .FromSqlRaw("select * from public.\"GetLanguageKvpByFormName\"(@LanguageType, @FormName)", 
                    new NpgsqlParameter("LanguageType", (int)languageType),
                    new NpgsqlParameter("FormName", formName))
                .ToList();
            
            var result = new Dictionary<string, string>();
            foreach (var kvp in languageKvpList)
            {
                result.Add(kvp.Key, kvp.Value);
            }
            return result;
        }
    }
}