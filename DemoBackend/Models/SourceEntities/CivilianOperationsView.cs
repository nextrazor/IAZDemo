using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class CivilianOperationsView
    {
        public string DesignationProcess { get; set; } = null!;
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? NameOperation { get; set; }
        public bool OperationType { get; set; }
        public double? SetupTime { get; set; }
        public double? OperationTime { get; set; }
        public string PbdidNomenclature { get; set; } = null!;
        public int UadmmaterialDefinitionId { get; set; }
        public string UadmmaterialDefinitionNid { get; set; } = null!;
        public int? NumbInRoute { get; set; }
    }
}
