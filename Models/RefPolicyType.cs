using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefPolicyType
    {
        public RefPolicyType()
        {
            TrnFilingRequestPolicyTypeXref = new HashSet<TrnFilingRequestPolicyTypeXref>();
        }

        public int PolicyTypeId { get; set; }
        public int PolicyClassId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string PolicyReferenceCode { get; set; }
        public string IndexOfEndorsementsPath { get; set; }
        public int? NavigatePolicyTypeId { get; set; }
        public bool? Active { get; set; }

        public RefPolicyClass PolicyClass { get; set; }
        public ICollection<TrnFilingRequestPolicyTypeXref> TrnFilingRequestPolicyTypeXref { get; set; }
    }
}
