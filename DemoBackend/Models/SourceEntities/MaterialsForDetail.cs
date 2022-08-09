using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class MaterialsForDetail
    {
        public int Idnorm { get; set; }
        public string IdproductPart { get; set; } = null!;
        public string IdproductMaterial { get; set; } = null!;

        public virtual Nomenclature IdproductMaterialNavigation { get; set; } = null!;
        public virtual Nomenclature IdproductPartNavigation { get; set; } = null!;
    }
}
