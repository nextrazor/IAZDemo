using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class HumanGroupsCountView
    {
        public decimal? Idprofession { get; set; }
        public decimal? Idrank { get; set; }
        public string? Rank { get; set; }
        public string NameProfession { get; set; } = null!;
        public int IdWorkshop { get; set; }
        public int IdWorkGroups { get; set; }
    }
}
