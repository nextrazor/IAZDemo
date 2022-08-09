using System;
using System.Collections.Generic;

namespace DemoBackend.Models
{
    public partial class OperationWaitTime
    {
        public string WorkOrder { get; set; } = null!;
        public string Operation { get; set; } = null!;
        public string KitNumber { get; set; } = null!;
        public double? WaitTimeAfterOp { get; set; }
        public double? WaitTimeBeforeOp { get; set; }
    }
}
