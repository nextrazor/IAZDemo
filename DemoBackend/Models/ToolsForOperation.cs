using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class ToolsForOperation
    {
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public decimal Idtool { get; set; }
        public decimal Quantity { get; set; }

        public virtual Tool IdtoolNavigation { get; set; } = null!;
        public virtual Operation Operation { get; set; } = null!;
    }
}
