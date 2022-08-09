using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Rank
    {
        public Rank()
        {
            Workers = new HashSet<Worker>();
            Idprofessions = new HashSet<Profession>();
        }

        public decimal Idrank { get; set; }
        public string Rank1 { get; set; } = null!;

        public virtual ICollection<Worker> Workers { get; set; }

        public virtual ICollection<Profession> Idprofessions { get; set; }
    }
}
