using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ResourceGroup
    {
        public ResourceGroup()
        {
            Operations = new HashSet<Operation>();
            Resources = new HashSet<Resource>();
        }

        public int IdresourceGroup { get; set; }
        public string NameResourceGroup { get; set; } = null!;
        public int IdWorkshop { get; set; }

        public virtual WorkShop IdWorkshopNavigation { get; set; } = null!;
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<Resource> Resources { get; set; }
    }
}
