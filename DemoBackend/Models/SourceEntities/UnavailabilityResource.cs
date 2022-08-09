using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UnavailabilityResource
    {
        public decimal Idrepair { get; set; }
        public decimal Idresource { get; set; }
        public DateTime BeginEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public string TypeRepair { get; set; } = null!;

        public virtual Resource IdresourceNavigation { get; set; } = null!;
    }
}
