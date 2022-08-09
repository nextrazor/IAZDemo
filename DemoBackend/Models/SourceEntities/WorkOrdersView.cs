using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkOrdersView
    {
        public string OrderNumber { get; set; } = null!;
        public string KitNumberFalse { get; set; } = null!;
        public string CodeProjectFalse { get; set; } = null!;
        public decimal Quantity { get; set; }
        public DateTime PlanBeginDate { get; set; }
        public DateTime DueDate { get; set; }
        public string Idproduct { get; set; } = null!;
        public decimal OperationCode { get; set; }
        public string? RealOperationNumber { get; set; }
        public string? DesignationProcess { get; set; }
        public double? Laboriousness { get; set; }
        public double? Setup { get; set; }
        public string UadmprocessesId { get; set; } = null!;
        public string AsPlannedBopid { get; set; } = null!;
        public string UadmoperationId { get; set; } = null!;
        public string UadmoperationNid { get; set; } = null!;
        public int UadmmaterialDefinitionId { get; set; }
        public string UadmmaterialDefinitionNid { get; set; } = null!;
        public string? Tse { get; set; }
        public string WorkShop { get; set; } = null!;
        public string WorkGroup { get; set; } = null!;
        public string? Compartments { get; set; }
        public decimal? ComplectQuantity { get; set; }
    }
}
