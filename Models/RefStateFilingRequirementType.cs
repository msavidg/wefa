using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefStateFilingRequirementType
    {
        public RefStateFilingRequirementType()
        {
            TrnStateFiling = new HashSet<TrnStateFiling>();
        }

        public int StateFilingRequirementTypeId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int FilingRequestTypeId { get; set; }

        public RefFilingRequestType FilingRequestType { get; set; }
        public ICollection<TrnStateFiling> TrnStateFiling { get; set; }
    }
}
