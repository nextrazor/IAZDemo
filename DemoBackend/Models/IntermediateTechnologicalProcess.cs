using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class IntermediateTechnologicalProcess
    {
        public string DesignationProcess { get; set; } = null!;
        public string Idproduct { get; set; } = null!;

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
    }
}
