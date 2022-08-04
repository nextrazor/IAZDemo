using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ResourceView
    {
        public decimal Idresource { get; set; }
        public int IdresourceGroup { get; set; }
        public string? InventoryNumber { get; set; }
        public string? Pko { get; set; }
        public string NameResource { get; set; } = null!;
        public string? Model { get; set; }
        public string WorkShop { get; set; } = null!;
        public string? WorkGroup { get; set; }
        public string NameResourceGroup { get; set; } = null!;
        public int? TypeResource { get; set; }
        public int? KindResource { get; set; }
        public int? Uadmid { get; set; }
        public string? Uadmnid { get; set; }
        public int? UadmgroupId { get; set; }
        public string? UadmgroupNid { get; set; }
    }
}
