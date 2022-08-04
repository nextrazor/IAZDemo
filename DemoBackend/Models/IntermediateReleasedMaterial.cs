using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class IntermediateReleasedMaterial
    {
        public int Idposition { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public string DesignationProcess { get; set; } = null!;
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public string NumberParty { get; set; } = null!;
        public string NumberMelt { get; set; } = null!;

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
        public virtual WorkOrder WorkOrder { get; set; } = null!;
    }
}
