using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Uadmnomenclature
    {
        public string Idproduct { get; set; } = null!;
        public int UadmmaterialDefinitionId { get; set; }
        public string UadmmaterialDefinitionNid { get; set; } = null!;

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
    }
}
