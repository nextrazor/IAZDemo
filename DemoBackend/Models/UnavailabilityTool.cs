using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UnavailabilityTool
    {
        public decimal Idevent { get; set; }
        public decimal Idtool { get; set; }
        public DateTime BeginEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public decimal Quantity { get; set; }

        public virtual Tool IdtoolNavigation { get; set; } = null!;
    }
}
