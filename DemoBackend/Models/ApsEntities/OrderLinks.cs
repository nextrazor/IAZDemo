using System.ComponentModel.DataAnnotations;

namespace IAZBackend.Models.ApsEntities
{
    public class OrderLink
    {
        public int DatasetId { get; set; }
        public virtual Dataset Dataset { get; set; } = null!;
        public virtual Order? FromOrder { get; set; }
        public int? FromOrderId { get; set; }
        public virtual Order? ToOrder { get; set; }
        public int? ToOrderId { get; set; }

        public override string ToString() => $"Link '{FromOrder}' - '{ToOrder}'";
    }
}
