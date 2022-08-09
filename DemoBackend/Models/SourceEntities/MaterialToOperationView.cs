using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class MaterialToOperationView
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public float ConsumptionRate { get; set; }
        public int UadmmaterialDefinitionId { get; set; }
        public string UadmmaterialDefinitionNid { get; set; } = null!;
        public string? DesignationProcess { get; set; }
        public string AsPlannedBopid { get; set; } = null!;
        public string UadmoperationId { get; set; } = null!;
        public string UadmoperationNid { get; set; } = null!;
    }
}
