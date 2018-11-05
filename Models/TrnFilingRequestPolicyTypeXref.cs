using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class TrnFilingRequestPolicyTypeXref
    {
        public int Id { get; set; }
        public int FilingRequestId { get; set; }
        public int PolicyTypeId { get; set; }
        public DateTime AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }

        public TrnFilingRequest FilingRequest { get; set; }
        public RefPolicyType PolicyType { get; set; }
    }
}
