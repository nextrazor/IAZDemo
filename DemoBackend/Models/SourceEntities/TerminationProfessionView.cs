using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class TerminationProfessionView
    {
        public decimal CodeProfession { get; set; }
        public decimal Idprofession { get; set; }
        public string NameProfession { get; set; } = null!;
    }
}
