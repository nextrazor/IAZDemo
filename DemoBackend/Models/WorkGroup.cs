using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkGroup
    {
        public WorkGroup()
        {
            LinkWokersToWorckShopGroups = new HashSet<LinkWokersToWorckShopGroup>();
            NomenclaturePlanFixeds = new HashSet<NomenclaturePlanFixed>();
            NomenclaturePlans = new HashSet<NomenclaturePlan>();
            Resources = new HashSet<Resource>();
            WorkOrders = new HashSet<WorkOrder>();
            IdWorkshops = new HashSet<WorkShop>();
        }

        public int IdWorkGroups { get; set; }
        public string WorkGroup1 { get; set; } = null!;

        public virtual ICollection<LinkWokersToWorckShopGroup> LinkWokersToWorckShopGroups { get; set; }
        public virtual ICollection<NomenclaturePlanFixed> NomenclaturePlanFixeds { get; set; }
        public virtual ICollection<NomenclaturePlan> NomenclaturePlans { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }

        public virtual ICollection<WorkShop> IdWorkshops { get; set; }
    }
}
