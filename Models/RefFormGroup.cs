using System;
using System.Collections.Generic;

namespace wefa.Models
{
    public partial class RefFormGroup
    {
        public int FormGroupId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int? PolicyClassId { get; set; }
        public int? OrderNum { get; set; }
        public int? UserId { get; set; }

        public RefPolicyClass PolicyClass { get; set; }
    }
}
