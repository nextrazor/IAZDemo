using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class NewTechProcessOperation
    {
        public string OrderNumber { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public string RealDesignationProcessWithRev { get; set; } = null!;
        public string? RealProduct { get; set; }
        public decimal? PartyQuantity { get; set; }
        public DateTime PlanBeginDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string? AccessoryProduct { get; set; }
        public string WorkShop { get; set; } = null!;
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string? DesignationProcess { get; set; }
        public string? Idproduct { get; set; }
        public decimal? Idresource { get; set; }
        public string? NameOperation { get; set; }
        public double? Setup { get; set; }
        public double? Laboriousness { get; set; }
        public decimal? CountWorkers { get; set; }
        public bool OperationType { get; set; }
        public int? IdresourceGroup { get; set; }
        public decimal? Sign { get; set; }
        public string? WorkGroup { get; set; }
        public int? NumbInRoute { get; set; }
    }
}
