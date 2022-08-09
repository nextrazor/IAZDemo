using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkOrdersShop
    {
        public string OrderNumber { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public string NumberOrder { get; set; } = null!;
        public decimal IdNomenclature { get; set; }
        public string NameResource { get; set; } = null!;
        public decimal? IdTechnicalProcess { get; set; }
        public decimal NumberOperation { get; set; }
        public DateTime SetupStart { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public decimal PlanQuantity { get; set; }
    }
}
