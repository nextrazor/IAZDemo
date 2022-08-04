using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Resource
    {
        public Resource()
        {
            Operations = new HashSet<Operation>();
            UnavailabilityResources = new HashSet<UnavailabilityResource>();
            WorkerCodes = new HashSet<Worker>();
        }

        public decimal Idresource { get; set; }
        public string? InventoryNumber { get; set; }
        public string? Pko { get; set; }
        public string NameResource { get; set; } = null!;
        public string? Model { get; set; }
        public int? IdWorkshop { get; set; }
        public int? IdWorkshopgroups { get; set; }
        public int? IdresourceGroup { get; set; }
        public int? TypeResource { get; set; }
        public int? KindResource { get; set; }

        public virtual WorkShop? IdWorkshopNavigation { get; set; }
        public virtual WorkGroup? IdWorkshopgroupsNavigation { get; set; }
        public virtual ResourceGroup? IdresourceGroupNavigation { get; set; }
        public virtual Uadmresource Uadmresource { get; set; } = null!;
        public virtual ICollection<Operation> Operations { get; set; }
        public virtual ICollection<UnavailabilityResource> UnavailabilityResources { get; set; }

        public virtual ICollection<Worker> WorkerCodes { get; set; }
    }
}
