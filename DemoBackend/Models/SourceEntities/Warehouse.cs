using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Warehouse
    {
        public Warehouse()
        {
            IntermediateWarehouseBalances = new HashSet<IntermediateWarehouseBalance>();
            WarehouseBalances = new HashSet<WarehouseBalance>();
        }

        public string WarehouseCode { get; set; } = null!;
        public string NameWarehouse { get; set; } = null!;

        public virtual ICollection<IntermediateWarehouseBalance> IntermediateWarehouseBalances { get; set; }
        public virtual ICollection<WarehouseBalance> WarehouseBalances { get; set; }
    }
}
