using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Uadmresource
    {
        public decimal Idresource { get; set; }
        public int IdresourceGroup { get; set; }
        public int Uadmid { get; set; }
        public string Uadmnid { get; set; } = null!;
        public int UadmgroupId { get; set; }
        public string UadmgroupNid { get; set; } = null!;

        public virtual Resource IdresourceNavigation { get; set; } = null!;
    }
}
