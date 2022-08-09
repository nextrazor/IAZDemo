using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WokersAndProfessionView
    {
        public string? NameProfession { get; set; }
        public string? Rank { get; set; }
        public decimal? CodeProfession { get; set; }
        public string WorkerCode { get; set; } = null!;
    }
}
