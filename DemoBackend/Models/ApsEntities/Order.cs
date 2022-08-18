namespace IAZBackend.Models.ApsEntities
{
    public partial class Order
    {
        public int OrderId { get; set; }
        public virtual Dataset Dataset { get; set; } = null!;
        public int DatasetId { get; set; }
        public virtual Resource? Resource { get; set; }
        public int? ResourceId { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public string PartNo { get; set; } = string.Empty;
        public string Product { get; set; } = string.Empty;
        public string ProjectCode { get; set; } = string.Empty;
        public string KitNumber { get; set; } = string.Empty;
        public double Quantity { get; set; }
        public int OpNo { get; set; }
        public string OperationName { get; set; } = string.Empty;
        public bool IsMilitary { get; set; } = false;
        public int? WorkGroup { get; set; }
        public double MidBatchQuantity { get; set; }
        public int ProcessTimeType { get; set; }
        public double OpTimePerItem { get; set; }
        public double BatchTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? DueDate { get; set; }
        public virtual List<OrderLink> LinksFrom { get; set; } = new List<OrderLink>();
        public virtual List<OrderLink> LinksTo { get; set; } = new List<OrderLink>();
        public virtual List<OrderSecConstraint> OrderSecConstraints { get; set; } = new List<OrderSecConstraint>();

        public override string ToString() => $"{OrderNo} - {OpNo}. {OperationName}";
    }

    public enum ProcessTimeType
    {
        TimePerItem = 0,
        TimePerBatch = 1
    }
}
