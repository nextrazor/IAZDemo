using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UadmrolesAndProffession
    {
        public int UadmrolesId { get; set; }
        public string ProfessionName { get; set; } = null!;
        public decimal CodeProfession { get; set; }

        public virtual Uadmrole Uadmroles { get; set; } = null!;
    }
}
