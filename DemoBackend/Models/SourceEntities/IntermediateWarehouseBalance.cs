using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class IntermediateWarehouseBalance
    {
        public int Idposition { get; set; }
        public string Idproduct { get; set; } = null!;
        public string WarehouseCode { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public decimal Quantity { get; set; }
        public string Unit { get; set; } = null!;

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
        public virtual Warehouse WarehouseCodeNavigation { get; set; } = null!;
    }
}
