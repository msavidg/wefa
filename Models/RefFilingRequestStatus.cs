using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefFilingRequestStatus
    {
        public RefFilingRequestStatus()
        {
            TrnFilingRequest = new HashSet<TrnFilingRequest>();
        }

        public int FilingRequestStatusId { get; set; }
        public int FilingRequestTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int OrderInFlow { get; set; }
        public string Group { get; set; }
        public bool? Active { get; set; }

        public RefFilingRequestType FilingRequestType { get; set; }
        public ICollection<TrnFilingRequest> TrnFilingRequest { get; set; }
    }
}
