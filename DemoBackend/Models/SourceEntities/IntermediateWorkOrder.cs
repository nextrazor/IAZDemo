using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class IntermediateWorkOrder
    {
        public string OrderNumber { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public decimal PartyQuantity { get; set; }
        public DateTime PlanBeginDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string AccessoryProduct { get; set; } = null!;
        public string WorkShop { get; set; } = null!;
        public decimal ProductionGroup { get; set; }

        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
    }
}
