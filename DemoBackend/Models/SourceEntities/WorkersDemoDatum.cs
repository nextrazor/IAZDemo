using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class WorkersDemoDatum
    {
        public string WorkerCode { get; set; } = null!;
        public string Fio { get; set; } = null!;
        public decimal? Idprofession { get; set; }
        public string? NameProfession { get; set; }
        public decimal? CodeProfession { get; set; }
        public string? WorkShop { get; set; }
        public string? WorkGroup { get; set; }
    }
}
