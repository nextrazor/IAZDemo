using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Uadmtool
    {
        public decimal Idtool { get; set; }
        public int? UadmdefinitionToolsId { get; set; }
        public int? UadmtoolsId { get; set; }

        public virtual Tool IdtoolNavigation { get; set; } = null!;
    }
}
