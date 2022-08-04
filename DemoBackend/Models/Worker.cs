using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Worker
    {
        public Worker()
        {
            ActualAvailabilities = new HashSet<ActualAvailability>();
            LinkWokersToWorckShopGroups = new HashSet<LinkWokersToWorckShopGroup>();
            UnavailabilityWorkers = new HashSet<UnavailabilityWorker>();
            Idresources = new HashSet<Resource>();
        }

        public string WorkerCode { get; set; } = null!;
        public string Fio { get; set; } = null!;
        public decimal? Idprofession { get; set; }
        public decimal? Idrank { get; set; }

        public virtual Profession? IdprofessionNavigation { get; set; }
        public virtual Rank? IdrankNavigation { get; set; }
        public virtual Uadmuser Uadmuser { get; set; } = null!;
        public virtual ICollection<ActualAvailability> ActualAvailabilities { get; set; }
        public virtual ICollection<LinkWokersToWorckShopGroup> LinkWokersToWorckShopGroups { get; set; }
        public virtual ICollection<UnavailabilityWorker> UnavailabilityWorkers { get; set; }

        public virtual ICollection<Resource> Idresources { get; set; }
    }
}
