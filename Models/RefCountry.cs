using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefCountry
    {
        public RefCountry()
        {
            RefState = new HashSet<RefState>();
            TrnFormFilingRequest = new HashSet<TrnFormFilingRequest>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool Active { get; set; }
        public int PhoneNumberFormatId { get; set; }

        public ICollection<RefState> RefState { get; set; }
        public ICollection<TrnFormFilingRequest> TrnFormFilingRequest { get; set; }
    }
}
