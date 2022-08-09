using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkOrder
    {
        public WorkOrder()
        {
            Defects = new HashSet<Defect>();
            Facts = new HashSet<Fact>();
            IntermediateReleasedMaterials = new HashSet<IntermediateReleasedMaterial>();
        }

        public string OrderNumber { get; set; } = null!;
        public string KitNumberFalse { get; set; } = null!;
        public string CodeProjectFalse { get; set; } = null!;
        public string DesignationProcess { get; set; } = null!;
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? RealOperationNumber { get; set; }
        public decimal OperationCode { get; set; }
        public string Idproduct { get; set; } = null!;
        public decimal PartyQuantity { get; set; }
        public DateTime PlanBeginDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string AccessoryProduct { get; set; } = null!;
        public int WorkShop { get; set; }
        public int WorkshopGroup { get; set; }

        public virtual TechnologicalProcess DesignationProcessNavigation { get; set; } = null!;
        public virtual Nomenclature IdproductNavigation { get; set; } = null!;
        public virtual WorkShop WorkShopNavigation { get; set; } = null!;
        public virtual WorkGroup WorkshopGroupNavigation { get; set; } = null!;
        public virtual ICollection<Defect> Defects { get; set; }
        public virtual ICollection<Fact> Facts { get; set; }
        public virtual ICollection<IntermediateReleasedMaterial> IntermediateReleasedMaterials { get; set; }
    }
}
