using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class RealWorkOrder
    {
        public string OrderNumber { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public string RealDesignationProcessWithRev { get; set; } = null!;
        public string? RealDesignationProcessWithoutRev { get; set; }
        public string? RealProduct { get; set; }
        public string OperationNumber { get; set; } = null!;
        public decimal OperationCode { get; set; }
        public decimal? PartyQuantity { get; set; }
        public DateTime PlanBeginDate { get; set; }
        public DateTime PlanEndDate { get; set; }
        public string? AccessoryProduct { get; set; }
        public string WorkShop { get; set; } = null!;
        public string? RealWorkshopGroup { get; set; }
        public int? OrderState { get; set; }
    }
}
