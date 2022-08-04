using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UadmtechnologicalOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string UadmprocessesId { get; set; } = null!;
        public string AsPlannedBopid { get; set; } = null!;
        public string ForNomenclature { get; set; } = null!;
        public string UadmoperationId { get; set; } = null!;
        public string UadmoperationNid { get; set; } = null!;
        public bool IsMilitary { get; set; }

        public virtual Nomenclature ForNomenclatureNavigation { get; set; } = null!;
        public virtual Operation Operation { get; set; } = null!;
    }
}
