using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{
    public class OrderLink
    {
        [Key]
        public int OrderLinksId { get; set; }
        public int DatasetId { get; set; }
        public Dataset Dataset { get; set; } = null!;
        public int? FromInternalSupplyOrder { get; set; }
        public int? ToInternalDemandOrder { get; set; }
        public Order? FromOrder { get; set; }
        public Order? ToOrder { get; set; }

        public override string ToString()
        {
            return $"Link '{FromOrder}' - '{ToOrder}'";
        }
    }
}
