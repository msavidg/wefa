using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefFormClass
    {
        public RefFormClass()
        {
            TrnFormFilingRequest = new HashSet<TrnFormFilingRequest>();
        }

        public string ClassName { get; set; }
        public int ClassOrder { get; set; }
        public int FormClassId { get; set; }
        public int PolicyClassId { get; set; }
        public string Code { get; set; }

        public RefPolicyClass PolicyClass { get; set; }
        public ICollection<TrnFormFilingRequest> TrnFormFilingRequest { get; set; }
    }
}
