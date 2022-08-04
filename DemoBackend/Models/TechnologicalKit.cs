using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class TechnologicalKit
    {
        public TechnologicalKit()
        {
            Nomenclatures = new HashSet<Nomenclature>();
        }

        public string NumberTk { get; set; } = null!;

        public virtual ICollection<Nomenclature> Nomenclatures { get; set; }
    }
}
