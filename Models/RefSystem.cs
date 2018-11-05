using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefSystem
    {
        public RefSystem()
        {
            TrnFilingRequest = new HashSet<TrnFilingRequest>();
        }

        public int SystemId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }

        public ICollection<TrnFilingRequest> TrnFilingRequest { get; set; }
    }
}
