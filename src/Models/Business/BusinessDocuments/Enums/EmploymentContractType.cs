using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// Type of the employment contract.
    /// </summary>
    public enum EmploymentContractType
    {
        [Display(Name = "Full Time Contract")]
        FullTimeContract,

        [Display(Name = "Part Time Contract")]
        PartTimeContract,

        [Display(Name = "Fixed Term Contract")]
        FixedTermContract,

        [Display(Name = "No Contract")]
        NoContract,

        [Display(Name = "Voluntary Work")]
        VoluntaryWork,

        [Display(Name = "Contract Of Mandate")]
        ContractOfMandate,

        [Display(Name = "Contract Of Specific Work")]
        ContractOfSpecificWork,

        [Display(Name = "Internship")]
        Internship,

        [Display(Name = "Freelance")]
        Freelance,

        [Display(Name = "Contractor")]
        Contractor,

        [Display(Name = "Agency Workers")]
        AgencyWorkers
    }
}