using Cims.WorkflowLib.Models.Business;
using Cims.WorkflowLib.Models.Business.InformationSystem;

namespace Cims.WorkflowLib.Models.Business
{
    public class Comment : BusinessEntityWF, IBusinessEntityWF
    {
        /// <summary>
        /// 
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public System.DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public UserAccount CreationAuthor { get; set; }
    }
}