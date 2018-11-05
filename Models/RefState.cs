using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefState
    {
        public RefState()
        {
            TrnStateFiling = new HashSet<TrnStateFiling>();
        }

        public int StateId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int CountryId { get; set; }

        public RefCountry Country { get; set; }
        public ICollection<TrnStateFiling> TrnStateFiling { get; set; }
    }
}
