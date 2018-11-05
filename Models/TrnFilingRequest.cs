using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class TrnFilingRequest
    {
        public TrnFilingRequest()
        {
            TrnFilingRequestCarrierXref = new HashSet<TrnFilingRequestCarrierXref>();
            TrnFilingRequestPolicyTypeXref = new HashSet<TrnFilingRequestPolicyTypeXref>();
            TrnFilingRequestReplaceFormXref = new HashSet<TrnFilingRequestReplaceFormXref>();
            TrnFormFilingRequest = new HashSet<TrnFormFilingRequest>();
            TrnStateFiling = new HashSet<TrnStateFiling>();
        }

        public int FilingRequestId { get; set; }
        public int FilingRequestTypeId { get; set; }
        public int FilingRequestStatusId { get; set; }
        public string SubmittedBy { get; set; }
        public DateTime SubmittedDate { get; set; }
        public int PolicyClassId { get; set; }
        public string Subject { get; set; }
        public string ComplianceFilingNumber { get; set; }
        public string ListItemId { get; set; }
        public string ListId { get; set; }
        public string TaskListId { get; set; }
        public string HistoryListId { get; set; }
        public string WorkflowId { get; set; }
        public int? RequestedById { get; set; }
        public DateTime AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }
        public int? SystemAffected { get; set; }
        public int? RequestPriority { get; set; }
        public string PriorityJustification { get; set; }
        public bool? BlockRelease { get; set; }
        public string BlockReleaseReason { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public string StatusComments { get; set; }
        public bool? IsActive { get; set; }

        public RefFilingRequestStatus FilingRequestStatus { get; set; }
        public RefFilingRequestType FilingRequestType { get; set; }
        public RefPolicyClass PolicyClass { get; set; }
        public RefPriority RequestPriorityNavigation { get; set; }
        public RefSystem SystemAffectedNavigation { get; set; }
        public ICollection<TrnFilingRequestCarrierXref> TrnFilingRequestCarrierXref { get; set; }
        public ICollection<TrnFilingRequestPolicyTypeXref> TrnFilingRequestPolicyTypeXref { get; set; }
        public ICollection<TrnFilingRequestReplaceFormXref> TrnFilingRequestReplaceFormXref { get; set; }
        public ICollection<TrnFormFilingRequest> TrnFormFilingRequest { get; set; }
        public ICollection<TrnStateFiling> TrnStateFiling { get; set; }
    }
}
