using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class HumanResourcesView
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public int? IdresourceGroup { get; set; }
        public string NameProfession { get; set; } = null!;
        public string Rank { get; set; } = null!;
        public decimal Idprofession { get; set; }
        public decimal Idrank { get; set; }
        public decimal? Nts { get; set; }
        public string? Pdop { get; set; }
    }
}
