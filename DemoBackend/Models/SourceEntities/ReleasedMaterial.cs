using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ReleasedMaterial
    {
        public int? Idposition { get; set; }
        public string? OrderNumber { get; set; }
        public string? KitNumber { get; set; }
        public string? CodeProject { get; set; }
        public string Idproduct { get; set; } = null!;
        public string? NumberParty { get; set; }
        public string? NumberMelt { get; set; }

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
    }
}
