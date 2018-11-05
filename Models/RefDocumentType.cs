using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefDocumentType
    {
        public RefDocumentType()
        {
            TrnFormFilingRequest = new HashSet<TrnFormFilingRequest>();
        }

        public int DocumentTypeId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public ICollection<TrnFormFilingRequest> TrnFormFilingRequest { get; set; }
    }
}
