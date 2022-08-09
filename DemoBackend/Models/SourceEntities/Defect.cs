using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class Defect
    {
        public decimal Idposition { get; set; }
        public string OrderNumber { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public string DesignationProcess { get; set; } = null!;
        public string DesignationOperation { get; set; } = null!;
        public string OperationNumber { get; set; } = null!;
        public string CodeProject { get; set; } = null!;
        public DateTime DateDefect { get; set; }
        public decimal CountDefect { get; set; }

        public virtual WorkOrder WorkOrder { get; set; } = null!;
    }
}
