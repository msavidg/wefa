using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class TrnFormFilingRequest
    {
        public int FormFilingRequestId { get; set; }
        public int FilingRequestId { get; set; }
        public int DocumentTypeId { get; set; }
        public int CountryId { get; set; }
        public int? FormClassId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string FormIdString { get; set; }
        public string BaseFormIdString { get; set; }
        public DateTime? EffectiveDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public DateTime? EditionDate { get; set; }
        public string FormType { get; set; }
        public bool CanHaveMultiples { get; set; }
        public string AdobeId { get; set; }
        public int AppliesToSubmission { get; set; }
        public int AppliesToQuote { get; set; }
        public int AppliesToBinder { get; set; }
        public int AppliesToPolicy { get; set; }
        public int AppliesToEndorsement { get; set; }
        public bool IsCommon { get; set; }
        public bool IsPremiumBearing { get; set; }
        public bool IncludeTermsOnQb { get; set; }
        public bool IncludeTermsOnDecPage { get; set; }
        public int? SubjectivityFormId { get; set; }
        public string SubjectivityDefaultText { get; set; }
        public int? OrderWithinClass { get; set; }
        public string FormDefaultComment { get; set; }
        public string SpecialBehavior { get; set; }
        public string SubCategory { get; set; }
        public bool Broadens { get; set; }
        public bool Restricts { get; set; }
        public bool Clarifies { get; set; }
        public bool WatermarkOnQuote { get; set; }
        public bool WatermarkOnBinder { get; set; }
        public bool WatermarkOnPolicy { get; set; }
        public bool WatermarkOnEndorsement { get; set; }
        public bool HasUserFillIns { get; set; }
        public bool HasSystemFillIns { get; set; }
        public string ChangeDetails { get; set; }
        public string PurposeOfForm { get; set; }
        public string ShortName { get; set; }
        public bool? ClaimsApprovalRequired { get; set; }
        public bool? IsNewForm { get; set; }
        public bool? ReplacesExistingForm { get; set; }
        public DateTime? ReplacesExisitingFormExpiryDate { get; set; }
        public string ReplacesExistingFormName { get; set; }
        public DateTime? ReplacesExistingFormEditionDate { get; set; }
        public int? RelatedFilingRequest { get; set; }
        public bool? Mandatory { get; set; }
        public bool? Optional { get; set; }
        public DateTime AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }
        public bool RetainUserFillIns { get; set; }
        public bool IncludeDataOnQuote { get; set; }
        public bool IncludeDataOnBinder { get; set; }
        public bool IncludeDataOnPolicy { get; set; }
        public bool IncludeDataOnEndorsement { get; set; }
        public bool? BypassWorkFlow { get; set; }
        public Guid? NavigateFormEditionId { get; set; }
        public Guid? ExistingFormsEditionId { get; set; }
        public int? Uatrejection { get; set; }
        public int? ChangeRequest { get; set; }
        public int? FormTemplateId { get; set; }

        public RefCountry Country { get; set; }
        public RefDocumentType DocumentType { get; set; }
        public TrnFilingRequest FilingRequest { get; set; }
        public RefFormClass FormClass { get; set; }
    }
}
