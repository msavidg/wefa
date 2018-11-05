using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefPolicyClass
    {
        public RefPolicyClass()
        {
            RefFormClass = new HashSet<RefFormClass>();
            RefFormGroup = new HashSet<RefFormGroup>();
            RefPolicyType = new HashSet<RefPolicyType>();
            TrnFilingRequest = new HashSet<TrnFilingRequest>();
        }

        public int PolicyClassId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ProductCode { get; set; }
        public string ClearanceProductCode { get; set; }
        public int InsuredInterestTypeId { get; set; }
        public int ClearanceMonths { get; set; }
        public string IndexOfEndorsementsPath { get; set; }
        public string UnapprovedBrokerEmailAddress { get; set; }
        public string FormRequestToEmailAddress { get; set; }
        public string FormRequestCcEmailAddress { get; set; }
        public string NoiseWords { get; set; }
        public int KytaxLineOfBusinessId { get; set; }
        public string NavigateClearancePolicyClassIds { get; set; }
        public string RenewalHistoryLimitCoverageCodes { get; set; }
        public string ReleaseNotificationEmailAddress { get; set; }
        public string WebsiteUrl { get; set; }
        public int WipGridDaysLimit { get; set; }
        public string SystemTypeCode { get; set; }
        public int? NavigateId { get; set; }
        public bool? Active { get; set; }
        public int? MaxClearanceRows { get; set; }
        public string NoiseCharacters { get; set; }
        public bool? RequireAcknowledgementOfValidationAlertsAndNotifications { get; set; }

        public ICollection<RefFormClass> RefFormClass { get; set; }
        public ICollection<RefFormGroup> RefFormGroup { get; set; }
        public ICollection<RefPolicyType> RefPolicyType { get; set; }
        public ICollection<TrnFilingRequest> TrnFilingRequest { get; set; }
    }
}
