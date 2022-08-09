using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class PlanTkcompositionView
    {
        public string OrderCode { get; set; } = null!;
        public string Tk { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public string? DesignationProduct { get; set; }
        public string? ProductModification { get; set; }
        public int Quantity { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal Laboriousness { get; set; }
        public string? WorkShop { get; set; }
        public string? WorkGroup { get; set; }
        public string DeliveryGriff { get; set; } = null!;
        public string PlanGriff { get; set; } = null!;
        public string СonsumerWorkshop { get; set; } = null!;
        public string UadmprocessesId { get; set; } = null!;
        public string AsPlannedBopid { get; set; } = null!;
        public int UadmmaterialDefinitionId { get; set; }
        public int? Uadmid { get; set; }
    }
}
