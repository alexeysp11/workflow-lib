using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.InformationSystem
{
    /// <summary>
    /// 
    /// </summary>
    public enum AuthProviderType
    {
        [Display(Name = "Standard")]
        Standard,
        
        [Display(Name = "LDAP/AD")]
        LdapAd
    }
}