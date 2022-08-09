using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class AdditionalGroup
    {
        public string WorkerCode { get; set; } = null!;
        public int IdWorkGroups { get; set; }
        public int IdWorkshop { get; set; }

        public virtual WorkGroup IdWorkGroupsNavigation { get; set; } = null!;
        public virtual WorkShop IdWorkshopNavigation { get; set; } = null!;
        public virtual Worker WorkerCodeNavigation { get; set; } = null!;
    }
}
