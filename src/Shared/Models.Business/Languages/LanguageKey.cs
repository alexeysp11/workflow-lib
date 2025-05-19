using WorkflowLib.Shared.Models.Business;

namespace WorkflowLib.Shared.Models.Business.Languages
{
    /// <summary>
    /// Language key.
    /// </summary>
    public class LanguageKey
    {
        /// <summary>
        /// ID of the business entity.
        /// </summary>
        public long Id { get; set; }
        
        /// <summary>
        /// Key of the language (e.g. name in English).
        /// </summary>
        public string Key { get; set; }
        
        /// <summary>
        /// Endonym of the language.
        /// </summary>
        public string Endonym { get; set; }
        
        /// <summary>
        /// Language type.
        /// </summary>
        public LanguageType LanguageType { get; set; }
        
        /// <summary>
        /// Business entity status.
        /// </summary>
        public BusinessEntityStatus BusinessEntityStatus { get; set; }
    }
}