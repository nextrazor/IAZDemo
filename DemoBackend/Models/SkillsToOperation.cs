using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class SkillsToOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public decimal CodeProfession { get; set; }
        public string ProfessionRank { get; set; } = null!;
        public decimal QuantityToOperation { get; set; }
        public decimal? Nts { get; set; }
        public string? Pdop { get; set; }
        public string NameProfession { get; set; } = null!;
        public string? ProfessionsUadmnid { get; set; }
        public string? ProfessionsUadmid { get; set; }
        public string AsPlannedBopid { get; set; } = null!;
        public string OperationUadmoperationId { get; set; } = null!;
        public string OperationUadmoperationNid { get; set; } = null!;
    }
}
