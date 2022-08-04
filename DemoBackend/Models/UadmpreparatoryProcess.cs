using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class UadmpreparatoryProcess
    {
        public int Id { get; set; }
        public string AsPlannedBopid { get; set; } = null!;
        public string ProcessId { get; set; } = null!;
    }
}
