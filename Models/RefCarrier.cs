using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefCarrier
    {
        public RefCarrier()
        {
            TrnFilingRequestCarrierXref = new HashSet<TrnFilingRequestCarrierXref>();
            TrnStateFiling = new HashSet<TrnStateFiling>();
        }

        public int CarrierId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string EnumValue { get; set; }

        public ICollection<TrnFilingRequestCarrierXref> TrnFilingRequestCarrierXref { get; set; }
        public ICollection<TrnStateFiling> TrnStateFiling { get; set; }
    }
}
