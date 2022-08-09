using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Profession
    {
        public Profession()
        {
            IntermediateProfessionsForOperations = new HashSet<IntermediateProfessionsForOperation>();
            Workers = new HashSet<Worker>();
            Idranks = new HashSet<Rank>();
        }

        public decimal Idprofession { get; set; }
        public string NameProfession { get; set; } = null!;
        public decimal? CodeProfession { get; set; }

        public virtual ICollection<IntermediateProfessionsForOperation> IntermediateProfessionsForOperations { get; set; }
        public virtual ICollection<Worker> Workers { get; set; }

        public virtual ICollection<Rank> Idranks { get; set; }
    }
}
