using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class LinkWokersToWorckShopGroup
    {
        public string WorkerCode { get; set; } = null!;
        public int IdWorkshop { get; set; }
        public int? IdWorkGroups { get; set; }

        public virtual WorkGroup? IdWorkGroupsNavigation { get; set; }
        public virtual WorkShop IdWorkshopNavigation { get; set; } = null!;
        public virtual Worker WorkerCodeNavigation { get; set; } = null!;
    }
}
