using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wefa.ViewModels
{
    public class FRMSRequest
    {
        public int FilingRequestId { get; set; }
        public string FilingRequest { get; set; }
        public string FilingRequestStatus { get; set; }
        public string DocumentType { get; set; }
        public string PolicyClass { get; set; }
        public string PolicyType { get; set; }
        public string BaseFormIdString { get; set; }
        public DateTime? EditionDate { get; set; }
        public string ShortName { get; set; }
        public string Name { get; set; }
        public string FrsName { get; set; }
        public bool? ReplacesExistingForm { get; set; }
        public string ReplacesExistingFormName { get; set; }
        public DateTime? ReplacesExistingFormEditionDate { get; set; }
    }
}
