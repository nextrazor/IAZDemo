using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ProfessionsWithRanksView
    {
        public string? Rank { get; set; }
        public string NameProfession { get; set; } = null!;
        public decimal? CodeProfession { get; set; }
        public decimal Idprofession { get; set; }
        public decimal? Idrank { get; set; }
        public string? Uadmnid { get; set; }
        public string? Uadmid { get; set; }
    }
}
