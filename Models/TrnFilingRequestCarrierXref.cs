using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class TrnFilingRequestCarrierXref
    {
        public int Id { get; set; }
        public int FilingRequestId { get; set; }
        public int CarrierId { get; set; }
        public DateTime AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }

        public RefCarrier Carrier { get; set; }
        public TrnFilingRequest FilingRequest { get; set; }
    }
}
