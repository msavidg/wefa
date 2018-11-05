using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefFilingRequestType
    {
        public RefFilingRequestType()
        {
            RefFilingRequestStatus = new HashSet<RefFilingRequestStatus>();
            RefStateFilingRequirementType = new HashSet<RefStateFilingRequirementType>();
            RefStateFilingStatus = new HashSet<RefStateFilingStatus>();
            TrnFilingRequest = new HashSet<TrnFilingRequest>();
        }

        public int FilingRequestTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool? Active { get; set; }

        public ICollection<RefFilingRequestStatus> RefFilingRequestStatus { get; set; }
        public ICollection<RefStateFilingRequirementType> RefStateFilingRequirementType { get; set; }
        public ICollection<RefStateFilingStatus> RefStateFilingStatus { get; set; }
        public ICollection<TrnFilingRequest> TrnFilingRequest { get; set; }
    }
}
