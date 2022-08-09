using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class NomenclaturePlanFixed
    {
        public string OrderCode { get; set; } = null!;
        public string Tk { get; set; } = null!;
        public string Idproduct { get; set; } = null!;
        public int ManufacturerWorkshopId { get; set; }
        public string СonsumerWorkshop { get; set; } = null!;
        public int IdWorkGroups { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Laboriousness { get; set; }
        public int Quantity { get; set; }
        public string DeliveryGriff { get; set; } = null!;
        public string PlanGriff { get; set; } = null!;

        public virtual WorkGroup IdWorkGroupsNavigation { get; set; } = null!;
        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
        public virtual WorkShop ManufacturerWorkshop { get; set; } = null!;
    }
}
