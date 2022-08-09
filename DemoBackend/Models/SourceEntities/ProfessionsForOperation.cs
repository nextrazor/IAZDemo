using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ProfessionsForOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public decimal CodeProfession { get; set; }
        public string Rank { get; set; } = null!;
        public decimal? Nts { get; set; }
        public string? Pdop { get; set; }
        public decimal Quantity { get; set; }
        public int? CivilOperationNumber { get; set; }

        public virtual Operation Operation { get; set; } = null!;
    }
}
