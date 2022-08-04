using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ActualAvailability
    {
        public decimal Idpassage { get; set; }
        public string WorkerCode { get; set; } = null!;
        public DateTime DateTimePassage { get; set; }

        public virtual Worker WorkerCodeNavigation { get; set; } = null!;
    }
}
