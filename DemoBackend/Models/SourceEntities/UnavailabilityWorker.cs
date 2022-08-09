using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UnavailabilityWorker
    {
        public string Idevent { get; set; } = null!;
        public string WorkerCode { get; set; } = null!;
        public DateTime BeginEvent { get; set; }
        public DateTime EndEvent { get; set; }

        public virtual Worker WorkerCodeNavigation { get; set; } = null!;
    }
}
