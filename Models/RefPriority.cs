using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefPriority
    {
        public RefPriority()
        {
            TrnFilingRequest = new HashSet<TrnFilingRequest>();
        }

        public int PriorityId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public DateTime AuditLastModified { get; set; }
        public string AuditLastModifiedBy { get; set; }

        public ICollection<TrnFilingRequest> TrnFilingRequest { get; set; }
    }
}
