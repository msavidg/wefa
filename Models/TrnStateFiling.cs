using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class TrnStateFiling
    {
        public int StateFilingId { get; set; }
        public int FilingRequestId { get; set; }
        public DateTime? FilingDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public DateTime? NavigateFormEffectiveDate { get; set; }
        public int StateFilingStatusId { get; set; }
        public int StateFilingRequirementTypeId { get; set; }
        public string Comment { get; set; }
        public int StateId { get; set; }
        public DateTime? AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }
        public int? CarrierId { get; set; }
        public DateTime? ProductionReleaseDate { get; set; }

        public RefCarrier Carrier { get; set; }
        public TrnFilingRequest FilingRequest { get; set; }
        public RefState State { get; set; }
        public RefStateFilingRequirementType StateFilingRequirementType { get; set; }
        public RefStateFilingStatus StateFilingStatus { get; set; }
    }
}
