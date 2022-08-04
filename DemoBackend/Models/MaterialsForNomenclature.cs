using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class MaterialsForNomenclature
    {
        public string Idproduct { get; set; } = null!;
        public string Idmaterial { get; set; } = null!;
        public string DesignationProcess { get; set; } = null!;
        public bool IsMainMaterial { get; set; }
        public float? ConsumptionRate { get; set; }

        public virtual TechnologicalProcess DesignationProcessNavigation { get; set; } = null!;
        public virtual Nomenclature IdmaterialNavigation { get; set; } = null!;
        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
    }
}
