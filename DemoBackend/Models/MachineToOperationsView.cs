using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class MachineToOperationsView
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string UadmprocessesId { get; set; } = null!;
        public string AsPlannedBopid { get; set; } = null!;
        public string UadmoperationId { get; set; } = null!;
        public string UadmoperationNid { get; set; } = null!;
        public int IdresourceGroup { get; set; }
        public string NameResourceGroup { get; set; } = null!;
        public int UadmgroupId { get; set; }
        public string UadmgroupNid { get; set; } = null!;
    }
}
