using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class TechnologicalProcess
    {
        public TechnologicalProcess()
        {
            MaterialsForNomenclatures = new HashSet<MaterialsForNomenclature>();
            Operations = new HashSet<Operation>();
            Sketches = new HashSet<Sketch>();
            WorkOrders = new HashSet<WorkOrder>();
        }

        public string DesignationProcess { get; set; } = null!;
        public string Idproduct { get; set; } = null!;

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
        public virtual ICollection<MaterialsForNomenclature> MaterialsForNomenclatures { get; set; }
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Sketch> Sketches { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
    }
}
