using System.ComponentModel.DataAnnotations;

namespace Cims.WorkflowLib.Models.Business.BusinessDocuments
{
    /// <summary>
    /// 
    /// </summary>
    public enum ContractType
    {
        // Sales
        [Display(Name = "Purchase Order")]
        PurchaseOrder,
        [Display(Name = "Renewal Order")]
        RenewalOrder,
        [Display(Name = "Sales Contract")]
        SalesContract,
        [Display(Name = "Vendor Agreement")]
        VendorAgreement,
        [Display(Name = "Warranty Contract")]
        WarrantyContract,

        // Marketing
        [Display(Name = "Advisory Agreement")]
        AdvisoryAgreement,
        [Display(Name = "Confidentiality Agreement")]
        ConfidentialityAgreement,
        [Display(Name = "Influencer Agreement")]
        InfluencerAgreement,
        [Display(Name = "Photography Release")]
        PhotographyRelease,
        [Display(Name = "Privacy Agreement")]
        PrivacyAgreement,

        // IT/Operation
        [Display(Name = "Cloud Computing Agreement")]
        CloudComputingAgreement,
        [Display(Name = "Equipment Lease Agreement")]
        EquipmentLeaseAgreement,
        [Display(Name = "Non Disclosure Agreement")]
        NonDisclosureAgreement,
        [Display(Name = "Property Lease Agreement")]
        PropertyLeaseAgreement,
        [Display(Name = "Security Agreement")]
        SecurityAgreement,
        [Display(Name = "Terms Of Use")]
        TermsOfUse,

        // Human Resources
        [Display(Name = "Director Service Agreement")]
        DirectorServiceAgreement,
        [Display(Name = "Employment Contract")]
        EmploymentContract,
        [Display(Name = "Employee Transfer Agreement")]
        EmployeeTransferAgreement,
        [Display(Name = "Independent Contractor Agreement")]
        IndependentContractorAgreement,
        [Display(Name = "Non-Complete Agreement")]
        NonCompleteAgreement,
        [Display(Name = "Recruitment Agreement")]
        RecruitmentAgreement,
        [Display(Name = "Termination Agreement")]
        TerminationAgreement,

        // Procurement
        [Display(Name = "Contract Amendment")]
        ContractAmendment,
        [Display(Name = "Joint Venture Agreement")]
        JointVentureAgreement,
        [Display(Name = "License Agreement")]
        LicenseAgreement,
        [Display(Name = "Master Service Agreement")]
        MasterServiceAgreement,
        [Display(Name = "Memorandum of understanding")]
        MemorandumOfUnderstandingAgreement,
        [Display(Name = "Partnership Agreement")]
        PartnershipAgreement,
        [Display(Name = "Promissory note")]
        PromissoryNote,
        [Display(Name = "Statement of work")]
        SatementOfWork
    }
}