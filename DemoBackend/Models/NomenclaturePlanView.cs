using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class NomenclaturePlanView
    {
        public string OrderCode { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public int? IdWorkshop { get; set; }
        public string Tk { get; set; } = null!;
        public string? DesignationProduct { get; set; }
        public decimal? CountInProduct { get; set; }
        public int ManufacturerWorkshopId { get; set; }
        public string СonsumerWorkshop { get; set; } = null!;
        public int IdWorkGroups { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Laboriousness { get; set; }
        public int Quantity { get; set; }
        public string PlanGriff { get; set; } = null!;
        public string DeliveryGriff { get; set; } = null!;
        public double? Ncmonth { get; set; }
    }
}
