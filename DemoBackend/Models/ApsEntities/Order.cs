using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{

    public class Order
    {
        [Key]
        public int OrdersId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public DateTime? DueDate { get; set; }
        public string OrderNo { get; set; } = string.Empty;
        public string OperationName { get; set; } = string.Empty;
        public int OpNo { get; set; }
        public double Quantity { get; set; }
        public double MidBatchQuantity { get; set; }
        public int DatasetId { get; set; }
        public Dataset Dataset { get; set; } = null!;
        public int Resource { get; set; }
        public Resource AssignedResource { get; set; } = null!;

        public override string ToString()
        {
            return $"{OrderNo} - {OpNo}. {OperationName}";
        }
    }
}
