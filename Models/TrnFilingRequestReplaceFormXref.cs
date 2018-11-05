using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class TrnFilingRequestReplaceFormXref
    {
        public int Id { get; set; }
        public int FilingRequestId { get; set; }
        public string BaseFormIdString { get; set; }
        public string FormEditionId { get; set; }
        public DateTime? EditionDate { get; set; }
        public DateTime AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }

        public TrnFilingRequest FilingRequest { get; set; }
    }
}
