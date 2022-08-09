using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkShop
    {
        public WorkShop()
        {
            LinkWokersToWorckShopGroups = new HashSet<LinkWokersToWorckShopGroup>();
            NomenclaturePlanFixeds = new HashSet<NomenclaturePlanFixed>();
            NomenclaturePlans = new HashSet<NomenclaturePlan>();
            Nomenclatures = new HashSet<Nomenclature>();
            ResourceGroups = new HashSet<ResourceGroup>();
            Resources = new HashSet<Resource>();
            Tools = new HashSet<Tool>();
            WorkOrders = new HashSet<WorkOrder>();
            IdWorkGroups = new HashSet<WorkGroup>();
        }

        public int IdWorkshop { get; set; }
        public string WorkShop1 { get; set; } = null!;

        public virtual ICollection<LinkWokersToWorckShopGroup> LinkWokersToWorckShopGroups { get; set; }
        public virtual ICollection<NomenclaturePlanFixed> NomenclaturePlanFixeds { get; set; }
        public virtual ICollection<NomenclaturePlan> NomenclaturePlans { get; set; }
        public virtual ICollection<Nomenclature> Nomenclatures { get; set; }
        public virtual ICollection<ResourceGroup> ResourceGroups { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<Tool> Tools { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public virtual ICollection<WorkGroup> IdWorkGroups { get; set; }
    }
}
