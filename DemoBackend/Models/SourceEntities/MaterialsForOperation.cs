using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class MaterialsForOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public float ConsumptionRate { get; set; }

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
        public virtual Operation Operation { get; set; } = null!;
    }
}
