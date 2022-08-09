using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class MilitaryOperationsView
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? NameOperation { get; set; }
        public bool OperationType { get; set; }
        public double? SetupTime { get; set; }
        public double? OperationTime { get; set; }
        public string PbdidNomenclature { get; set; } = null!;
        public int MilitaryFinalMaterialId { get; set; }
        public string MilitaryFinalMaterialNid { get; set; } = null!;
    }
}
